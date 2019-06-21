using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marco : Player
{
  // Start is called before the first frame update
  private void Awake()
  {

    InitStateMachine();
    WalkSpeed = 3.4f;
    m_speedMultiplier = 4.0f;
    FallSpeed = 29.4f;
    IsFacingRight = true;
    m_canFire = true;
    m_grenadesLeft = m_maxGrenades;
    m_isSlug = false;
    m_torsoAnimator = m_torso.GetComponent<Animator>();
    m_legsAnimator = m_Legs.GetComponent<Animator>();

  }

  private void Update()
  {
    if(m_ammoLeft <= 0)
    {
      m_weapon = m_handgun;
    }
  }

  private void FixedUpdate()
  {
    m_playerStateMachine.OnState(this); //Start's up the state machine with the idle state
  }

  /// <summary>
  /// Function to jump using Unity's physics called on the playerJumpstate
  /// </summary>
  public override void Jump()
  {
    m_horizontalSpeed = Input.GetAxisRaw("Horizontal");

    m_jumpSpeed -= Gravity * Time.fixedDeltaTime;
    transform.position = new Vector3(transform.position.x + m_horizontalSpeed * Time.fixedDeltaTime * m_speedMultiplier,
      transform.position.y + m_jumpSpeed * Time.fixedDeltaTime,
      transform.position.z);
    

  }

  /// <summary>
  /// Function to walk using the GO's position. Called in playerWalstate
  /// </summary>
  public override void walk()
  {
    Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
    transform.position += horizontal * Time.deltaTime * WalkSpeed;
  }

  public override void collectItem(int m_ammount, ItemType.E itemType)
  {
    switch (itemType)
    {
      case ItemType.E.kGas:
        m_score = m_ammount;
        break;

      case ItemType.E.kScore:

        break;
    }
  }

  public override void collectWeapon(int m_ammount, WeaponItemKind.E itemType)
  {
    switch (itemType)
    {
      case WeaponItemKind.E.kHeavyMachine:
        equipWeapon(m_heavyMachinePrefab);
        break;

      case WeaponItemKind.E.kFlameShot:
        //Give score
        break;

      case WeaponItemKind.E.kRocketLaunch:
        //GiveScore
        break;
    }
  }

  /// <summary>
  /// Used to initiate the player's state machine
  /// </summary>
  protected override void InitStateMachine()
  {
    m_playerStateMachine = new StateMachine<Marco>();
    playerIdleState = new MarcoIdle(m_playerStateMachine);
    playerWalkState = new MarcoWalk(m_playerStateMachine);
    playerJumpState = new MarcoJump(m_playerStateMachine);
    playerFallState = new MarcoFallState(m_playerStateMachine);
    playeParachuteFallState = new MarcoParachuteState(m_playerStateMachine);

    m_playerStateMachine.Init(playeParachuteFallState, this);
  }

  public override void shootWeapon()
  {
    
    if (Time.time > m_weapon.getFireRate() + m_lastShot)
    {
      m_weapon.Shoot();
      m_lastShot = Time.time;
      if(m_weapon.m_weaponKind != WeaponItemKind.E.kHangun)
      {
        m_ammoLeft -= m_weapon.m_ammoSpent;
      }
    }
    
  }

  /// <summary>
  /// Function to instantiate a grenade
  /// </summary>
  public override void throwBomb()
  {
    if (Time.time > 0.3f)
    {
      if (m_grenadesLeft > 0 && m_grenadesOnScreen < 2)
      {
        float g = Physics.gravity.magnitude;

        Grenade newGrenade;
        newGrenade = Instantiate(m_grenade, m_weaponSlot.transform.position, m_weaponSlot.transform.rotation);
        float vSpeed = (newGrenade.m_totalTime * g) / 2;
        newGrenade.GetComponent<Rigidbody2D>().velocity = new Vector3(m_weaponSlot.transform.right.x * newGrenade.m_hSpeed, vSpeed, 0);
        --m_grenadesLeft;
        ++m_grenadesOnScreen;
      }
    }
  }

  public void parachuteFall()
  {
    m_fallSpeed = m_parachuteFallSpeed;
    transform.position = new Vector3(transform.position.x,
      transform.position.y - (m_fallSpeed * Time.fixedDeltaTime),
      transform.position.z);
  }

  public void equipWeapon(Weapon weapon)
  {
    if (m_weapon == weapon)
    {
      m_ammoLeft = m_weapon.m_ammo;
    }
    else
    {
      m_weapon.gameObject.SetActive(false);
      m_weapon = weapon;
      m_weapon.gameObject.SetActive(true);
      m_ammoLeft = weapon.m_ammo;
    }
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if(collision.gameObject.tag == "Item")
    {

    }
  }

  /// <summary>
  /// The state machine that handles all the states for the player
  /// </summary>
  private StateMachine<Marco> m_playerStateMachine;


  /// <summary>
  /// Variable to keep track and limit the number of grenades on screen
  /// </summary>
  [SerializeField]
  public int m_grenadesOnScreen;

  /// <summary>
  /// The upper GO that handles the sprites and animator for the torso
  /// </summary>
  public GameObject m_torso;
  
  /// <summary>
  /// The lower GO that handles the sprites and animator for the torso
  /// </summary>
  public GameObject m_Legs;

  /// <summary>
  /// The Animator from the torso GO that handles it's animations
  /// </summary>
  public Animator m_torsoAnimator;

  /// <summary>
  /// The Animator from the legs GO that handles it's animations
  /// </summary>
  public Animator m_legsAnimator;

  /// <summary>
  /// The states for all the actions of the player to create the state machine
  /// </summary>
  public MarcoIdle playerIdleState;
  public MarcoWalk playerWalkState;
  public MarcoJump playerJumpState;
  public MarcoFallState playerFallState;
  public MarcoParachuteState playeParachuteFallState;

  /// <summary>
  /// The Prefab to instantiate grenades
  /// </summary>
  public Grenade m_grenade;

  /// <summary>
  /// Value to control how long it takes for the gun to interpolate from front to up and down 
  /// </summary>
  [SerializeField]
  [Range(1.0f, 30.0f)]
 public float m_guninterpolation = 10.0f;

  /// <summary>
  /// Value to control how long it takes for the gun to interpolate from front to up and down 
  /// </summary>
  [SerializeField]
  [Range(0.0f, 10.0f)]
  public float m_parachuteFallSpeed = 0.0f;



  /// <summary>
  /// Reference to the handgun
  /// </summary>
  public Handgun m_handgun;

  /// <summary>
  /// Prefab to create a new heavy machine gun
  /// </summary>
  public HeavyMachineGun m_heavyMachinePrefab;

  //public FlameShot m_flameShotPrefab;
  //public RocketLauncher m_rocketLauncherPrefab;
  

}

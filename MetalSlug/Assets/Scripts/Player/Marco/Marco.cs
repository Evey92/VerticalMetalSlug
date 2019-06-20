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
    m_jumpForce = 7.6f;
    IsFacingRight = true;
    m_canFire = true;
    m_grenadesLeft = 10;

    m_torsoAnimator = m_torso.GetComponent<Animator>();

  }


  private void FixedUpdate()
  {
    m_playerStateMachine.OnState(this); //Start's up the state machine with the idle state
  }

  /// <summary>
  /// Function to jump using Unity's physics called on the playerJumpstate
  /// </summary>
  public override void jump()
  {
    IsGrounded = false;

    m_horizontalSpeed = Input.GetAxisRaw("Horizontal");
    GetComponent<Rigidbody2D>().AddForce(new Vector2(m_horizontalSpeed* m_speedMultiplier, 1 * m_jumpForce), ForceMode2D.Impulse);

  }

  /// <summary>
  /// Function to walk using the GO's position. Called in playerWalstate
  /// </summary>
  public override void walk()
  {
    Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
    transform.position += horizontal * Time.deltaTime * WalkSpeed;
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

    m_playerStateMachine.Init(playerIdleState, this);
  }

  public override void shootWeapon()
  {
    
    if (Time.time > m_weapon.getFireRate() + m_lastShot)
    {
      m_weapon.Shoot();
      m_lastShot = Time.time;
    }
    
  }

  /// <summary>
  /// Function to 
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

  /// <summary>
  /// The state machine that handles all the states for the player
  /// </summary>
  private StateMachine<Marco> m_playerStateMachine;

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

  /// <summary>
  /// The Prefab to instantiate grenades
  /// </summary>
  public Grenade m_grenade;

  /// <summary>
  /// Variable to keep track and limit the number of grenades on screen
  /// </summary>
  public int m_grenadesOnScreen;

  /// <summary>
  /// Value to control how long it takes for the gun to interpolate from front to up and down 
  /// </summary>
  public float m_guninterpolation;


}

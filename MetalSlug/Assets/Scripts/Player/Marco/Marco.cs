using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marco : Player
{
  // Start is called before the first frame update
  private void Awake()
  {

    InitStateMachine();
    m_walkSpeed = 3;
    m_speedMultiplier = 5;
    m_extraGravity = 29.4f;
    m_isFacingRight = true;
    m_canFire = true;
  }

  private void FixedUpdate()
  {
    m_playerStateMachine.OnState(this);
  }

  // Update is called once per frame
  void Update()
  {

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

  public override void throwBomb()
  {
    float g = Physics.gravity.magnitude;

    Grenade newGrenade;
    newGrenade = Instantiate(m_grenade, m_weaponSlot.transform.position, m_weaponSlot.transform.rotation);
    float vSpeed = (newGrenade.m_totalTime * g) / 2;
    newGrenade.GetComponent<Rigidbody2D>().velocity = new Vector3(m_weaponSlot.transform.right.x *newGrenade.m_hSpeed, vSpeed, 0);

  }

  private StateMachine<Marco> m_playerStateMachine;


  /// <summary>
  /// Public members
  /// </summary>
  public MarcoIdle playerIdleState;
  public MarcoWalk playerWalkState;
  public MarcoJump playerJumpState;
  public MarcoFallState playerFallState;
  public Grenade m_grenade;
  
}

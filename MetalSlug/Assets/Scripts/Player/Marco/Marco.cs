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

  public override void ShootWeapon()
  {
    if (Time.time > m_weapon.getFireRate() + m_lastShot)
    {
      m_weapon.Shoot();
      m_lastShot = Time.time;
    }

  }

  private StateMachine<Marco> m_playerStateMachine;


  /// <summary>
  /// Public members
  /// </summary>
  public MarcoIdle playerIdleState;
  public MarcoWalk playerWalkState;
  public MarcoJump playerJumpState;
  public MarcoFallState playerFallState;
  
}

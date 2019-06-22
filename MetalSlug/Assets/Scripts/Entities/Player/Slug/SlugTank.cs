using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugTank : Player
{
  public Animator anim;
  private void Awake()
  {

    InitStateMachine();
    m_walkSpeed = 3;
    m_speedMultiplier = 5;
    FallSpeed = 29.4f;
    m_isFacingRight = true;
    m_canFire = true;
    anim = this.GetComponentInChildren<Animator>();
  }

  private void FixedUpdate()
  {
    m_playerStateMachine.OnState(this);
    anim.SetBool("isGrounded", m_isGrounded);
    //anim.SetFloat("Speed", m_walkSpeed);
    
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
    m_playerStateMachine = new StateMachine<SlugTank>();
    slugIdleState = new SlugIdle(m_playerStateMachine);
    slugWalkState = new SlugWalk(m_playerStateMachine);
    slugJumpState = new SlugJump(m_playerStateMachine);
    slugFallState = new SlugFallState(m_playerStateMachine);

    m_playerStateMachine.Init(slugIdleState, this);
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
    
  }


  public override void walk()
  {
    //Do Stuf
  }
  private StateMachine<SlugTank> m_playerStateMachine;


  /// <summary>
  /// Public members
  /// </summary>
  public SlugIdle slugIdleState;
  public SlugWalk slugWalkState;
  public SlugJump slugJumpState;
  public SlugFallState slugFallState;
}

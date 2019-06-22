using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugTank : Player
{
  private void Awake()
  {

    InitStateMachine();
    m_walkSpeed = 3;
    m_speedMultiplier = 5;
    FallSpeed = 29.4f;
    m_isFacingRight = true;
    m_canFire = true;
  }

  private void FixedUpdate()
  {
    m_playerStateMachine.OnState(this);
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

  public override void collectItem(int m_ammount, ItemType.E itemType)
  {
    switch (itemType)
    {
      case ItemType.E.kGas:
        {
          if (m_gasLeft >= m_maxGas)
          {
            m_score = m_ammount;
          }
          else
          {
            m_gasLeft += m_ammount;
            if (m_gasLeft > m_maxGas)
            {
              m_gasLeft = m_maxGas;
            }
          }
        }
        break;

      case ItemType.E.kScore:
        m_score = m_ammount;
        break;
    }
  }

  public override void collectWeapon(int m_ammount, WeaponItemKind.E itemType)
  {
    switch (itemType)
    {
      case WeaponItemKind.E.kHeavyMachine:
        {
          //Give Score
        }
        break;

      case WeaponItemKind.E.kFlameShot:
        //Give score
        break;

      case WeaponItemKind.E.kRocketLaunch:
        //GiveScore
        break;
    }
  }

  private StateMachine<SlugTank> m_playerStateMachine;


  /// <summary>
  /// Public members
  /// </summary>
  public SlugIdle slugIdleState;
  public SlugWalk slugWalkState;
  public SlugJump slugJumpState;
  public SlugFallState slugFallState;

  public float m_gasLeft = 100.0f;
  public float m_maxGas = 100.0f;
}

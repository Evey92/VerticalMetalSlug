using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoFallState : State<AmmoItem>
{
  public AmmoFallState(StateMachine<AmmoItem> stateMachine)
: base(stateMachine) { }

  public override void OnStateEnter(AmmoItem ammo)
  {
    Debug.Log("Weapon fall state");
    ammo.FallSpeed = 0;
  }

  public override void OnStatePreUpdate(AmmoItem ammo)
  {
    if (ammo.IsGrounded)
    {
      m_StateMachine.ToState(ammo.ammoIdleState, ammo);
    }
  }

  public override void OnStateUpdate(AmmoItem ammo)
  {
    ammo.Fall();

  }

  public override void OnStateExit(AmmoItem ammo)
  {
    ammo.FallSpeed = 0;

  }
}

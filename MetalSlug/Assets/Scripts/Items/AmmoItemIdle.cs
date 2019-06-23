using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoItemIdle : State<AmmoItem>
{
  // Start is called before the first frame update
  public AmmoItemIdle(StateMachine<AmmoItem> stateMachine)
: base(stateMachine) { }

  public override void OnStateEnter(AmmoItem Ammo)
  {
    Debug.Log("Weapon item idle");
  }

  public override void OnStatePreUpdate(AmmoItem Ammo)
  {
    if (!Ammo.IsGrounded)
    {
      m_StateMachine.ToState(Ammo.ammoFallState, Ammo);
      Ammo.IsGrounded = false;
    }
    if (Ammo.m_wasPickedup)
    {
      m_StateMachine.ToState(Ammo.ammoPickedUpstate, Ammo);

    }
  }

  public override void OnStateUpdate(AmmoItem Ammo)
  {

  }

  public override void OnStateExit(AmmoItem Ammo)
  {

  }
}

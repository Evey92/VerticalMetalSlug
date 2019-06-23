using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDestroyed : State<AmmoItem>
{
  public AmmoDestroyed(StateMachine<AmmoItem> stateMachine)
: base(stateMachine) { }

  public override void OnStateEnter(AmmoItem ammo)
  {
    ammo.Destroy();
  }

  public override void OnStatePreUpdate(AmmoItem ammo)
  {

  }

  public override void OnStateUpdate(AmmoItem ammo)
  {

  }

  public override void OnStateExit(AmmoItem ammo)
  {

  }
}

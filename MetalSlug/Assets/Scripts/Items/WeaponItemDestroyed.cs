using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItemDestroyed : State<WeaponItem>
{
  public WeaponItemDestroyed(StateMachine<WeaponItem> stateMachine)
: base(stateMachine) { }

  public override void OnStateEnter(WeaponItem weapon)
  {
    weapon.Destroy();
  }

  public override void OnStatePreUpdate(WeaponItem weapon)
  {
    
  }

  public override void OnStateUpdate(WeaponItem weapon)
  {

  }

  public override void OnStateExit(WeaponItem weapon)
  {

  }
}

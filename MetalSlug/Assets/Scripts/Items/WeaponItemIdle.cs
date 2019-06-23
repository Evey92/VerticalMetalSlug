using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItemIdle : State<WeaponItem>
{
  public WeaponItemIdle(StateMachine<WeaponItem> stateMachine)
  : base(stateMachine) { }

  public override void OnStateEnter(WeaponItem weapon)
  {
    Debug.Log("Weapon item idle");
  }

  public override void OnStatePreUpdate(WeaponItem weapon)
  {
    if (!weapon.IsGrounded)
    {
      m_StateMachine.ToState(weapon.weaponFallState, weapon);
      weapon.IsGrounded = false;
    }
    if(weapon.m_wasPickedup)
    {
      m_StateMachine.ToState(weapon.weaponPickedUpstate, weapon);

    }
  }

  public override void OnStateUpdate(WeaponItem weapon)
  {
  
  }

  public override void OnStateExit(WeaponItem weapon)
  {

  }
}

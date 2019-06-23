using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItemFall : State<WeaponItem>
{
  public WeaponItemFall(StateMachine<WeaponItem> stateMachine)
  : base(stateMachine) { }

  public override void OnStateEnter(WeaponItem weapon)
  {
    Debug.Log("Weapon fall state");
    weapon.FallSpeed = 0;
  }

  public override void OnStatePreUpdate(WeaponItem weapon)
  {
    if (weapon.IsGrounded)
    {
      m_StateMachine.ToState(weapon.weaponIdleState, weapon);
    }
  }

  public override void OnStateUpdate(WeaponItem weapon)
  {
    weapon.Fall();

  }

  public override void OnStateExit(WeaponItem weapon)
  {
    weapon.FallSpeed = 0;

  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItemPickedUp : State<WeaponItem>
{
  public WeaponItemPickedUp(StateMachine<WeaponItem> stateMachine)
  : base(stateMachine) { }

  public override void OnStateEnter(WeaponItem weapon)
  {
    Debug.Log("Item picked up");
    weapon.m_audioSource.PlayOneShot(weapon.m_pickUpClip);
  }

  public override void OnStatePreUpdate(WeaponItem weapon)
  {
    m_StateMachine.ToState(weapon.weaponDestroyedstate, weapon);

  }

  public override void OnStateUpdate(WeaponItem weapon)
  {

  }

  public override void OnStateExit(WeaponItem character)
  {

  }
}

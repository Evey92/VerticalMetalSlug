using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickedUpState : State<AmmoItem>
{
  public AmmoPickedUpState(StateMachine<AmmoItem> stateMachine)
: base(stateMachine) { }

  public override void OnStateEnter(AmmoItem ammo)
  {
    Debug.Log("Item picked up");
    ammo.m_audioSource.PlayOneShot(ammo.m_pickUpClip);
  }

  public override void OnStatePreUpdate(AmmoItem ammo)
  {
    m_StateMachine.ToState(ammo.ammoDestroyedstate, ammo);

  }

  public override void OnStateUpdate(AmmoItem ammo)
  {

  }

  public override void OnStateExit(AmmoItem ammo)
  {

  }
}

using System;
using UnityEngine;

public class MarcoFallState : State<Marco> 
{
  public MarcoFallState(StateMachine<Marco> stateMachine)
  : base(stateMachine) { }

  public override void OnStateEnter(Marco character)
  {
    Debug.Log("Entered Fall state");
    character.FallSpeed = 0;

  }

  public override void OnStatePreUpdate(Marco character)
  {
   if(character.IsGrounded)
    {
      m_StateMachine.ToState(character.playerIdleState, character);
    }

   if(Input.GetButtonDown("Fire1"))
    {
      character.shootWeapon();
    }
  }

  public override void OnStateUpdate(Marco character)
  {
    character.Fall();
  }

  public override void OnStateExit(Marco character)
  {
    character.FallSpeed = 0;

  }
}

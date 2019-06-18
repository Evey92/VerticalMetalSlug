using System;
using UnityEngine;

public class PlayerFallState : State<Player> 
{
  public PlayerFallState(StateMachine<Player> stateMachine)
  : base(stateMachine) { }

  public override void OnStateEnter(Player character)
  {
    Debug.Log("Entered Fall state");

    // Play falling animation 
  }

  public override void OnStatePreUpdate(Player character)
  {
   if(character.m_isGrounded)
    {
      m_StateMachine.ToState(character.playerIdleState, character);
    }
  }

  public override void OnStateUpdate(Player character)
  {
    Debug.Log("I'm Falling"); 
  }

  public override void OnStateExit(Player character)
  {
    
  }
}

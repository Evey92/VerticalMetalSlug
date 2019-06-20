using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarcoParachuteState : State<Marco>
{
  public MarcoParachuteState(StateMachine<Marco> stateMachine)
    : base(stateMachine) { }

  public override void OnStateEnter(Marco character)
  {
    Debug.Log("Parachuting");
  }

  public override void OnStatePreUpdate(Marco character)
  {
    if (character.IsGrounded)
    {
      m_StateMachine.ToState(character.playerIdleState, character);
    }
  }

  public override void OnStateUpdate(Marco character)
  {
    character.parachuteFall();
  }

  public override void OnStateExit(Marco character)
  {
    character.FallSpeed = 0;
  }
}

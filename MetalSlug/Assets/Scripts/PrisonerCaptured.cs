using System;
using UnityEngine;

public class PrisonerCaptured : State<Prisoner>
{
  public PrisonerCaptured(StateMachine<Prisoner> stateMachine)
    : base(stateMachine) { }


  public override void OnStateEnter(Prisoner prisoner)
  {
    Debug.Log("Prisoner enter Captured");
    Debug.Log(prisoner.m_prisonerState.ToString());
  }

  public override void OnStatePreUpdate(Prisoner prisoner)
  {
    // TODO: If prisoner is freed, go respective tag
    if (prisoner.IsGrounded)
    {

    }
    else
    {

    }
  }

  public override void OnStateUpdate(Prisoner prisoner)
  {

  }

  public override void OnStateExit(Prisoner prisoner)
  {

  }
}

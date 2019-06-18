using System;
using UnityEngine;

public class PrisonerCaptured : State<Prisoner>
{
  public PrisonerCaptured(StateMachine<Prisoner> stateMachine)
    : base(stateMachine) { }
    

  public override void OnStateEnter(Prisoner prisoner)
  {
    Debug.Log("Prisoner enter Captured");
  }

  public override void OnStatePreUpdate(Prisoner prisoner)
  {

  }

  public override void OnStateUpdate(Prisoner prisoner)
  {

  }

  public override void OnStateExit(Prisoner prisoner)
  {

  }
}

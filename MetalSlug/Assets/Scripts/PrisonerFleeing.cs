using System;
using UnityEngine;

public class PrisonerFleeing : State<Prisoner>
{
  public PrisonerFleeing(StateMachine<Prisoner> stateMachine)
    : base(stateMachine) { }


  public override void OnStateEnter(Prisoner prisoner)
  {
    Debug.Log("Prisoner enter Fleeing");
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

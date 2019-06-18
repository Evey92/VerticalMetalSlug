using System;
using UnityEngine;

public class PrisonerFalling : State<Prisoner>
{
  public PrisonerFalling(StateMachine<Prisoner> stateMachine)
    : base(stateMachine) { }


  public override void OnStateEnter(Prisoner prisoner)
  {
    Debug.Log("Prisoner enter Falling");
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

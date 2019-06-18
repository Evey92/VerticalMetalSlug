using System;
using UnityEngine;

public class PrisonerWalk : State<Prisoner>
{
  public PrisonerWalk(StateMachine<Prisoner> stateMachine)
    : base(stateMachine) { }

  public override void OnStateEnter(Prisoner prisoner)
  {
    Debug.Log("Prisoner enter Walk");
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

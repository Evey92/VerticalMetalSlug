using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarcoDieState : State<Marco>
{
  MarcoDieState(StateMachine<Marco> stateMachine)
  : base(stateMachine) { }

  public override void OnStateEnter(Marco character)
  {
  }
  public override void OnStatePreUpdate(Marco character)
  {
  }

  public override void OnStateUpdate(Marco character)
  {
  }

  public override void OnStateExit(Marco character)
  {
  }
}

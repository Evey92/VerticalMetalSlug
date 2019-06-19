using System;
using UnityEngine;

public class RebelJumping : State<Rebel>
{
  public RebelJumping(StateMachine<Rebel> stateMachine)
  : base(stateMachine) { }

  public override void OnStateEnter(Rebel rebel)
  {
    Debug.Log("Entered " + this.ToString() + " state.");
  }

  public override void OnStatePreUpdate(Rebel rebel)
  {

  }

  public override void OnStateUpdate(Rebel rebel)
  {

  }

  public override void OnStateExit(Rebel rebel)
  {

  }
}

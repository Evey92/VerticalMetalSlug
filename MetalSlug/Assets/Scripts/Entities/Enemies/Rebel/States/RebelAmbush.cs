using System;
using UnityEngine;

public class RebelAmbush : State<Rebel>
{
  public RebelAmbush(StateMachine<Rebel> stateMachine)
  : base(stateMachine) { }

  public override void OnStateEnter(Rebel rebel)
  {
    Debug.Log("Entered " + this.ToString() + " state.");
  }

  public override void OnStatePreUpdate(Rebel rebel)
  {
    if (rebel.HP <= 0)
    {
      m_StateMachine.ToState(rebel.rebelDie, rebel);
    }
  }

  public override void OnStateUpdate(Rebel rebel)
  {
    // TODO: Add a AmbushFall speed, and AmbushHorizontal speed
  }

  public override void OnStateExit(Rebel rebel)
  {

  }
}

using System;
using UnityEngine;

public class RebelThrow : State<Rebel>
{
  public RebelThrow(StateMachine<Rebel> stateMachine)
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
    Debug.Log("Throwing grenade");
    rebel.throwBomb();

    m_StateMachine.ToState(rebel.rebelRun, rebel);
  }

  public override void OnStateUpdate(Rebel rebel)
  {

  }

  public override void OnStateExit(Rebel rebel)
  {

  }
}

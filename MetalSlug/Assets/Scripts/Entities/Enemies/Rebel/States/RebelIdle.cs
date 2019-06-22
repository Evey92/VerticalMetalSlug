using System;
using UnityEngine;

public class RebelIdle : State<Rebel>
{
  public RebelIdle(StateMachine<Rebel> stateMachine)
  : base(stateMachine) { }

  public override void OnStateEnter(Rebel rebel)
  {
    Debug.Log("Entered " + this.ToString() + " state.");
  }

  public override void OnStatePreUpdate(Rebel rebel)
  {
    // TOOD: Should actually go to Panic State and then either run or flee
    if (Vector3.Distance(rebel.transform.position, rebel.NearestPlayer.transform.position) <
     rebel.PlayerDetectRadius)
    {
      if (!rebel.IsFacingRight)
      {
        rebel.IsFacingRight = true;
      }
      m_StateMachine.ToState(rebel.rebelRun, rebel);
    }

    if (rebel.HP <= 0)
    {
      m_StateMachine.ToState(rebel.rebelDie, rebel);
    }
  }

  public override void OnStateUpdate(Rebel rebel)
  {

  }

  public override void OnStateExit(Rebel rebel)
  {

  }
}

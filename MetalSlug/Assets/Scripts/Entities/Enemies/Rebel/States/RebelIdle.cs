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
    if (rebel.HP <= 0)
    {
      m_StateMachine.ToState(rebel.rebelDie, rebel);
    }
    float playerDistance = Vector3.Distance(rebel.transform.position, rebel.NearestPlayer.transform.position);
    //if(Something Random)
    //{
    //  m_StateMachine.ToState(rebel.rebelRun, rebel);
    //}
    //if (playerDistance <= rebel.ThreatRadius && m_courage < 5)
    //{
    //  m_StateMachine.ToState(rebel.rebelPanic, rebel); 
    //}
    //if ()
    //{
    //  m_StateMachine.ToState(rebel., rebel);
    //}
  }

  public override void OnStateUpdate(Rebel rebel)
  {

  }

  public override void OnStateExit(Rebel rebel)
  {

  }
}

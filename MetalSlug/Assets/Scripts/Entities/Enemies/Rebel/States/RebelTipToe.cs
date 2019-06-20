using System;
using UnityEngine;

public class RebelTipToe : State<Rebel>
{
  public RebelTipToe(StateMachine<Rebel> stateMachine)
  : base(stateMachine) { }

  public override void OnStateEnter(Rebel rebel)
  {
    Debug.Log("Entered " + this.ToString() + " state.");
  }

  public override void OnStatePreUpdate(Rebel rebel)
  {
    if (!rebel.IsGrounded)
    {
      m_StateMachine.ToState(rebel.rebelFall, rebel);
    }
    // TODO: If player is detected, go to run state or flee state
    if(rebel.HP<=0)
    {
      m_StateMachine.ToState(rebel.rebelDie, rebel);
    }
  }

  public override void OnStateUpdate(Rebel rebel)
  {
    if (rebel.IsFacingRight)
    {
      rebel.transform.position = new Vector3(rebel.transform.position.x + rebel.TipToeSpeed * Time.fixedDeltaTime,
        rebel.transform.position.y,
        rebel.transform.position.z);
    }
    else
    {
      rebel.transform.position = new Vector3(rebel.transform.position.x - rebel.TipToeSpeed * Time.fixedDeltaTime,
        rebel.transform.position.y,
        rebel.transform.position.z);
    }
  }

  public override void OnStateExit(Rebel rebel)
  {

  }
}

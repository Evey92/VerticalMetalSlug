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

    if (Vector3.Distance(rebel.transform.position, rebel.NearestPlayer.transform.position) <
      rebel.PlayerDetectRadius)
    {
      // TODO: Add a random or something to make it go to flee or something else
      if (!rebel.IsFacingRight)
      {
        rebel.IsFacingRight = true;
      }
      m_StateMachine.ToState(rebel.rebelWalk, rebel);
    }

    if (Vector3.Distance(rebel.transform.position, rebel.NearestPlayer.transform.position) <
     rebel.ThreatRadius)
    {
      if (!rebel.IsFacingRight)
      {
        rebel.IsFacingRight = true;
      }
      m_StateMachine.ToState(rebel.rebelFlee, rebel); // TODO: Should actually knife the player and go to run
    }

    if (rebel.HP <= 0)
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

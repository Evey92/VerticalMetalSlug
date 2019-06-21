using System;
using UnityEngine;

public class RebelRun : State<Rebel>
{
  public RebelRun(StateMachine<Rebel> stateMachine)
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

    if (rebel.NearestPlayer != null)
    {
      if (Vector3.Distance(rebel.transform.position, rebel.NearestPlayer.transform.position) >
        (rebel.PlayerDetectRadius + rebel.SafeZone))
      {
        if (rebel.IsFacingRight)
        {
          rebel.IsFacingRight = false;
          m_StateMachine.ToState(rebel.rebelWalk, rebel);
        }
      }

      if (Vector3.Distance(rebel.transform.position, rebel.NearestPlayer.transform.position) <
        rebel.PlayerDetectRadius)
      {
        if (!rebel.IsFacingRight)
        {
          rebel.IsFacingRight = true;
        }
      }
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
      rebel.transform.position = new Vector3(rebel.transform.position.x + rebel.RunSpeed * Time.fixedDeltaTime,
        rebel.transform.position.y,
        rebel.transform.position.z);
    }
    else
    {
      rebel.transform.position = new Vector3(rebel.transform.position.x - rebel.RunSpeed * Time.fixedDeltaTime,
        rebel.transform.position.y,
        rebel.transform.position.z);
    }
  }

  public override void OnStateExit(Rebel rebel)
  {

  }
}

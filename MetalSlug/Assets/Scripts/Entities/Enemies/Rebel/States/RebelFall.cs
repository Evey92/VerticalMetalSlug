using System;
using UnityEngine;

public class RebelFall : State<Rebel>
{
  public RebelFall(StateMachine<Rebel> stateMachine)
  : base(stateMachine) { }

  public override void OnStateEnter(Rebel rebel)
  {
    Debug.Log("Entered " + this.ToString() + " state.");
    rebel.FallSpeed = 0.0f;
  }

  public override void OnStatePreUpdate(Rebel rebel)
  {
    if (rebel.HP <= 0)
    {
      m_StateMachine.ToState(rebel.rebelDie, rebel);
    }

    if (rebel.IsGrounded)
    {
      m_StateMachine.ToState(rebel.rebelRun, rebel);
    }    
  }

  public override void OnStateUpdate(Rebel rebel)
  {
    rebel.Fall();
    // TODO: Based on previous state, use respective speed
    if(m_StateMachine.LastState == rebel.rebelWalk)
    {
      if (rebel.IsFacingRight)
      {
        rebel.transform.position = new Vector3(rebel.transform.position.x + rebel.WalkSpeed * Time.fixedDeltaTime,
          rebel.transform.position.y,
          rebel.transform.position.z);
      }
      else
      {
        rebel.transform.position = new Vector3(rebel.transform.position.x - rebel.WalkSpeed * Time.fixedDeltaTime,
          rebel.transform.position.y,
          rebel.transform.position.z);
      }
    }
    if(m_StateMachine.LastState==rebel.rebelRun)
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
  }

  public override void OnStateExit(Rebel rebel)
  {

  }
}

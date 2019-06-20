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
    if(rebel.IsGrounded)
    {
      m_StateMachine.ToState(rebel.rebelWalk, rebel);
    }
    if (rebel.HP <= 0)
    {
      m_StateMachine.ToState(rebel.rebelDie, rebel);
    }
  }

  public override void OnStateUpdate(Rebel rebel)
  {
    rebel.FallSpeed += (rebel.Gravity * Time.fixedDeltaTime * Time.fixedDeltaTime);
    rebel.transform.position = new Vector3(rebel.transform.position.x,
      rebel.transform.position.y - (rebel.FallSpeed),
      rebel.transform.position.z);
    // TODO: Based on previous state, use respective speed
  }

  public override void OnStateExit(Rebel rebel)
  {

  }
}

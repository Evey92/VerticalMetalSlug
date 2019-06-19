using System;
using UnityEngine;

public class RebelJumping : State<Rebel>
{
  public RebelJumping(StateMachine<Rebel> stateMachine)
  : base(stateMachine) { }

  public override void OnStateEnter(Rebel rebel)
  {
    Debug.Log("Entered " + this.ToString() + " state.");
    rebel.JumpStartPosition = rebel.transform.position.y;
    rebel.IsJumping = true;
    rebel.CalculateInitialJumpSpeed();
  }

  public override void OnStatePreUpdate(Rebel rebel)
  {
    if (rebel.JumpSpeed <= 0.0f)
    {
      m_StateMachine.ToState(rebel.rebelFall, rebel);
    }
  }

  public override void OnStateUpdate(Rebel rebel)
  {
    rebel.JumpSpeed -= rebel.Gravity * Time.fixedDeltaTime;
    rebel.transform.position = new Vector3(rebel.transform.position.x,
      rebel.transform.position.y + rebel.JumpSpeed * Time.fixedDeltaTime,
      rebel.transform.position.z);
  }

  public override void OnStateExit(Rebel rebel)
  {
    rebel.IsJumping = false;
  }
}

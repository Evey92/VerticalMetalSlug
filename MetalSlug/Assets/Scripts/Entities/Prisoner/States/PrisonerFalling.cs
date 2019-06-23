using System;
using UnityEngine;

public class PrisonerFalling : State<Prisoner>
{
  public PrisonerFalling(StateMachine<Prisoner> stateMachine)
    : base(stateMachine) { }


  public override void OnStateEnter(Prisoner prisoner)
  {
    prisoner.Anim.SetBool("isGrounded", prisoner.IsGrounded);
    Debug.Log("Prisoner enter Falling");
    prisoner.FallSpeed = 0.0f;
  }

  public override void OnStatePreUpdate(Prisoner prisoner)
  {
    if (prisoner.IsGrounded)
    {
      m_StateMachine.ToState(prisoner.prisonerWalk, prisoner);
    }
  }

  public override void OnStateUpdate(Prisoner prisoner)
  {
      prisoner.FallSpeed += prisoner.Gravity * prisoner.Gravity * Time.fixedDeltaTime;
      prisoner.transform.position = new Vector3(prisoner.transform.position.x,
      prisoner.transform.position.y - (prisoner.FallSpeed * Time.fixedDeltaTime),
      prisoner.transform.position.z);
  }

  public override void OnStateExit(Prisoner prisoner)
  {
    prisoner.FallSpeed = 0.0f;
  }
}

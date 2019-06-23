using System;
using UnityEngine;

public class PrisonerCaptured : State<Prisoner>
{
  public PrisonerCaptured(StateMachine<Prisoner> stateMachine)
    : base(stateMachine) { }


  public override void OnStateEnter(Prisoner prisoner)
  {
    Debug.Log("Prisoner enter Captured");
    Debug.Log(prisoner.CapturedState.ToString());
  }

  public override void OnStatePreUpdate(Prisoner prisoner)
  {
    if (prisoner.IsFree)
    {
      if (prisoner.IsGrounded)
      {
        m_StateMachine.ToState(prisoner.prisonerWalk, prisoner);
      }
      else
      {
        m_StateMachine.ToState(prisoner.prisonerFalling, prisoner);
      }
    }
  }

  public override void OnStateUpdate(Prisoner prisoner)
  {
    prisoner.Anim.SetBool("HasGifted", prisoner.DroppedItem);
    prisoner.Anim.SetBool("isfree", prisoner.IsFree);
    prisoner.Anim.SetBool("isGrounded", prisoner.IsGrounded);
  }

  public override void OnStateExit(Prisoner prisoner)
  {

  }
}

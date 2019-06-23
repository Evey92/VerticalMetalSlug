using System;
using UnityEngine;

public class PrisonerRescued : State<Prisoner>
{
  public PrisonerRescued(StateMachine<Prisoner> stateMachine)
    : base(stateMachine) { }


  public override void OnStateEnter(Prisoner prisoner)
  {
    Debug.Log("Prisoner enter Rescued");
    prisoner.Anim.SetBool("isfree", prisoner.IsFree);
    prisoner.Anim.SetBool("isGrounded", prisoner.DroppedItem);
  }

  public override void OnStatePreUpdate(Prisoner prisoner)
  {

  }

  public override void OnStateUpdate(Prisoner prisoner)
  {
    
  }

  public override void OnStateExit(Prisoner prisoner)
  {

  }
}

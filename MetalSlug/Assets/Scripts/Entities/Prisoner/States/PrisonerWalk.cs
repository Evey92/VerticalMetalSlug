using System;
using UnityEngine;

public class PrisonerWalk : State<Prisoner>
{
  public PrisonerWalk(StateMachine<Prisoner> stateMachine)
    : base(stateMachine) { }

  public override void OnStateEnter(Prisoner prisoner)
  {
    prisoner.Anim.SetBool("isfree", prisoner.IsFree);
    prisoner.Anim.SetBool("isGrounded", prisoner.IsGrounded);
    prisoner.Anim.SetBool("HasGifted", prisoner.DroppedItem);
    Debug.Log("Prisoner enter Walk");
  }

  public override void OnStatePreUpdate(Prisoner prisoner)
  {
    if (!prisoner.IsGrounded)
    {
      m_StateMachine.ToState(prisoner.prisonerFalling, prisoner);
    }
    if (prisoner.DroppedItem)
    {
      m_StateMachine.ToState(prisoner.prisonerFleeing, prisoner);
    }
  }

  public override void OnStateUpdate(Prisoner prisoner)
  {
    if (prisoner.IsFacingRight)
    {
      prisoner.transform.position = new Vector3(prisoner.transform.position.x + Time.fixedDeltaTime * prisoner.WalkSpeed,
        prisoner.transform.position.y,
        prisoner.transform.position.z);
      if (prisoner.StartRight)
      {
        if (prisoner.transform.position.x > prisoner.EndPosition)
        {
          prisoner.IsFacingRight = false;
          prisoner.sprite.flipX = false;
        }
      }
      else
      {
        if (prisoner.transform.position.x > prisoner.StartPosition)
        {
          prisoner.IsFacingRight = false;
          prisoner.sprite.flipX = false;
        }
      }
    }
    else
    {
      prisoner.transform.position = new Vector3(prisoner.transform.position.x - Time.fixedDeltaTime * prisoner.WalkSpeed,
        prisoner.transform.position.y,
        prisoner.transform.position.z);
      if (prisoner.StartRight)
      {
        if (prisoner.transform.position.x < prisoner.StartPosition)
        {
          prisoner.IsFacingRight = true;
          prisoner.sprite.flipX = true;
        }
      }
      else
      {
        if (prisoner.transform.position.x < prisoner.EndPosition)
        {
          prisoner.IsFacingRight = true;
          prisoner.sprite.flipX = true;
        }
      }
    }
  }

 
}

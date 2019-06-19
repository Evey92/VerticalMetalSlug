using System;
using UnityEngine;

public class PrisonerWalk : State<Prisoner>
{
  public PrisonerWalk(StateMachine<Prisoner> stateMachine)
    : base(stateMachine) { }

  public override void OnStateEnter(Prisoner prisoner)
  {
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
        }
      }
      else
      {
        if (prisoner.transform.position.x > prisoner.StartPosition)
        {
          prisoner.IsFacingRight = false;
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
        }
      }
      else
      {
        if (prisoner.transform.position.x < prisoner.EndPosition)
        {
          prisoner.IsFacingRight = true;
        }
      }
    }
  }

  public override void OnStateExit(Prisoner prisoner)
  {

  }
}

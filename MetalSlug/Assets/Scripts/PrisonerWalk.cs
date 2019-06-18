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
    if (prisoner.WalkRight)
    {
      prisoner.transform.position = new Vector3(prisoner.transform.position.x + Time.fixedDeltaTime * prisoner.WalkingSpeed,
        prisoner.transform.position.y,
        prisoner.transform.position.z);
      if (prisoner.StartRight)
      {
        if (prisoner.transform.position.x > prisoner.EndPosition)
        {
          prisoner.WalkRight = false;
        }
      }
      else
      {
        if (prisoner.transform.position.x > prisoner.StartPosition)
        {
          prisoner.WalkRight = false;
        }
      }
    }
    else
    {
      prisoner.transform.position = new Vector3(prisoner.transform.position.x - Time.fixedDeltaTime * prisoner.WalkingSpeed,
        prisoner.transform.position.y,
        prisoner.transform.position.z);
      if (prisoner.StartRight)
      {
        if (prisoner.transform.position.x < prisoner.StartPosition)
        {
          prisoner.WalkRight = true;
        }
      }
      else
      {
        if (prisoner.transform.position.x < prisoner.EndPosition)
        {
          prisoner.WalkRight = true;
        }
      }
    }
  }

  public override void OnStateExit(Prisoner prisoner)
  {

  }
}

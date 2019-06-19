using System;
using UnityEngine;

public class PrisonerFleeing : State<Prisoner>
{
  public PrisonerFleeing(StateMachine<Prisoner> stateMachine)
    : base(stateMachine) { }


  public override void OnStateEnter(Prisoner prisoner)
  {
    Debug.Log("Prisoner enter Fleeing");
  }

  public override void OnStatePreUpdate(Prisoner prisoner)
  {

  }

  public override void OnStateUpdate(Prisoner prisoner)
  {
    prisoner.transform.position = new Vector3(prisoner.transform.position.x - Time.fixedDeltaTime * prisoner.FleeSpeed,
      prisoner.transform.position.y,
      prisoner.transform.position.z);
    if (!prisoner.IsGrounded)
    {
      prisoner.FallSpeed += 9.8f * 9.8f * Time.deltaTime; // TODO: Specify a gravity value
      prisoner.transform.position = new Vector3(prisoner.transform.position.x,
      prisoner.transform.position.y - Time.fixedDeltaTime * prisoner.FallSpeed,
      prisoner.transform.position.z);
    }
    else
    {
      if (prisoner.FallSpeed != 0.0f)
      {
        prisoner.FallSpeed = 0.0f;
      }
    }
  }

  public override void OnStateExit(Prisoner prisoner)
  {

  }
}

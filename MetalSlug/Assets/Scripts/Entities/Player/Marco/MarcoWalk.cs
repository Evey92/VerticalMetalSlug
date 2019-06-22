using System;
using UnityEngine;

public class MarcoWalk : State<Marco>
{

  public MarcoWalk(StateMachine<Marco> stateMachine)
  : base(stateMachine){ }

  public override void OnStateEnter(Marco character)
  {
    //character.walk();
    character.m_isMoving = true;
  }

  public override void OnStatePreUpdate(Marco character)
  {
    if (Input.GetAxisRaw("Horizontal") == 0) 
    {
      m_StateMachine.ToState(character.playerIdleState, character);
    }
    else if(Input.GetAxisRaw("Horizontal") < 0)
    {
      character.transform.rotation = Quaternion.Euler(0, 180, 0);
      character.IsFacingRight = false;
    }
    else if (Input.GetAxisRaw("Horizontal") > 0)
    {
      character.transform.rotation = Quaternion.Euler(0, 0, 0);
      character.IsFacingRight = true;
    }

    if (Input.GetButtonDown("Jump"))
    {
      m_StateMachine.ToState(character.playerJumpState, character);
    }

    if (Input.GetButtonDown("Fire1"))
    {
      character.shootWeapon();
    }
    else if (Input.GetButtonDown("Fire2"))
    {
      character.throwBomb();
    }
    if (!character.IsGrounded)
    {
      m_StateMachine.ToState(character.playerFallState, character);
    }
  }

  public override void OnStateUpdate(Marco character)
  {
    character.walk();
  }

  public override void OnStateExit(Marco character)
  {
    character.m_isMoving = false;

  }
}

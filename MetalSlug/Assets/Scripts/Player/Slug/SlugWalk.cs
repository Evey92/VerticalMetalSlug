using System;
using UnityEngine;

public class SlugWalk : State<SlugTank>
{

  public SlugWalk(StateMachine<SlugTank> stateMachine)
  : base(stateMachine){ }

  public override void OnStateEnter(SlugTank character)
  {

    Debug.Log("Entered Walk state");


  }

  public override void OnStatePreUpdate(SlugTank character)
  {
    if (Input.GetAxisRaw("Horizontal") == 0) 
    {
      m_StateMachine.ToState(character.slugIdleState, character);
    }
    else if(Input.GetAxisRaw("Horizontal") < 0)
    {
      character.transform.localRotation = Quaternion.Euler(0, 180, 0);
    }
    else if (Input.GetAxisRaw("Horizontal") > 0)
    {
      character.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    if (Input.GetButtonDown("Jump"))
    {
      m_StateMachine.ToState(character.slugJumpState, character);
    }

    if (Input.GetButtonDown("Fire1"))
    {
      character.shootWeapon();
    }
  }

  public override void OnStateUpdate(SlugTank character)
  {
    Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
    character.transform.position += horizontal * Time.deltaTime * character.WalkSpeed;


  }

  public override void OnStateExit(SlugTank character)
  {
    
  }
}

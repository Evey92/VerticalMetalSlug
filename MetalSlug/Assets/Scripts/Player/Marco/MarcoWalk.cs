using System;
using UnityEngine;

public class MarcoWalk : State<Marco>
{

  public MarcoWalk(StateMachine<Marco> stateMachine)
  : base(stateMachine){ }

  public override void OnStateEnter(Marco character)
  {

    Debug.Log("Entered Walk state");


  }

  public override void OnStatePreUpdate(Marco character)
  {
    if (Input.GetAxisRaw("Horizontal") == 0) 
    {
      m_StateMachine.ToState(character.playerIdleState, character);
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
      m_StateMachine.ToState(character.playerJumpState, character);
    }

    if (Input.GetButtonDown("Fire1"))
    {
      character.ShootWeapon();
    }
  }

  public override void OnStateUpdate(Marco character)
  {
    Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
    character.transform.position += horizontal * Time.deltaTime * character.WalkSpeed;


  }

  public override void OnStateExit(Marco character)
  {
    
  }
}

using System;
using UnityEngine;

public class PlayerWalk : State<Player>
{

  public PlayerWalk(StateMachine<Player> stateMachine)
  : base(stateMachine){ }

  public override void OnStateEnter(Player character)
  {

    Debug.Log("Entered Walk state");


  }

  public override void OnStatePreUpdate(Player character)
  {
    if (Input.GetAxisRaw("Horizontal") == 0) 
    {
      m_StateMachine.ToState(character.playerIdleState, character);
    }
    else if(Input.GetButtonDown("Jump"))
    {
      m_StateMachine.ToState(character.playerJumpState, character);
    }
  }

  public override void OnStateUpdate(Player character)
  {
    Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
    character.transform.position += horizontal * Time.deltaTime * character.m_walkSpeed;


  }

  public override void OnStateExit(Player character)
  {
    
  }
}

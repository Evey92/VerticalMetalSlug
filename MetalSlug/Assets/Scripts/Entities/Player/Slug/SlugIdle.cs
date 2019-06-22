using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugIdle : State<SlugTank>
{
  public SlugIdle(StateMachine<SlugTank> stateMachine)
  : base(stateMachine){  }

  /// <summary>
  /// Used to declare actions that will take place when the state is entered
  /// </summary>
  /// <param name="character"></param>
  public override void OnStateEnter(SlugTank character)
  {
    Debug.Log("Entered Idle state");
    //Just to make sure we don't go through the floor
    character.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
    
  }

  /// <summary>
  /// Used to check if it is necessary to change state before updating game logic
  /// </summary>
  /// <param name="character"></param>
  public override void OnStatePreUpdate(SlugTank character)
  {
    if (Input.GetButtonDown("Jump"))
    {
      m_StateMachine.ToState(character.slugJumpState, character);
    }
    else if (Input.GetAxisRaw("Horizontal") != 0)
    {
      m_StateMachine.ToState(character.slugWalkState, character);
      
    }

    if(character.GetComponent<Rigidbody2D>().velocity.y < 0)
    {
      m_StateMachine.ToState(character.slugFallState, character);
    }

    if (Input.GetButtonDown("Fire1"))
    {
      character.shootWeapon();
    }
  }

  /// <summary>
  /// Logic update specific to this state
  /// </summary>
  /// <param name="character"></param>
  public override void OnStateUpdate(SlugTank character)
  {
    Debug.Log("im idle");
    
  }

  /// <summary>
  /// Used to declare actions that will take place before exiting this state
  /// </summary>
  /// <param name="character"></param>
  public override void OnStateExit(SlugTank character) { }
}

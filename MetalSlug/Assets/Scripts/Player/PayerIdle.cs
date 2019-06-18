using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : State<Player>
{
  public PlayerIdle(StateMachine<Player> stateMachine)
  : base(stateMachine){  }

  /// <summary>
  /// Used to declare actions that will take place when the state is entered
  /// </summary>
  /// <param name="character"></param>
  public override void OnStateEnter(Player character)
  {
    Debug.Log("Entered Idle state");

  }

  /// <summary>
  /// Used to check if it is necessary to change state before updating game logic
  /// </summary>
  /// <param name="character"></param>
  public override void OnStatePreUpdate(Player character)
  {
    if (Input.GetButtonDown("Jump"))
    {
      m_StateMachine.ToState(character.playerJumpState, character);
    }
    else if (Input.GetAxisRaw("Horizontal") != 0)
    {
      m_StateMachine.ToState(character.playerWalkState, character);
    }

    if(character.GetComponent<Rigidbody2D>().velocity.y < 0)
    {
      m_StateMachine.ToState(character.playerFallState, character);
    }
  }

  /// <summary>
  /// Logic update specific to this state
  /// </summary>
  /// <param name="character"></param>
  public override void OnStateUpdate(Player character)
  {
    Debug.Log("im idle");
    
  }

  /// <summary>
  /// Used to declare actions that will take place before exiting this state
  /// </summary>
  /// <param name="character"></param>
  public override void OnStateExit(Player character) { }
}

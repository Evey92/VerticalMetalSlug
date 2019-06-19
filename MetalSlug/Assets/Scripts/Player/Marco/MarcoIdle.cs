using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarcoIdle : State<Marco>
{
  public MarcoIdle(StateMachine<Marco> stateMachine)
  : base(stateMachine){  }

  /// <summary>
  /// Used to declare actions that will take place when the state is entered
  /// </summary>
  /// <param name="character"></param>
  public override void OnStateEnter(Marco character)
  {
    
    //Just to make sure we don't go through the floor
    character.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
  }

  /// <summary>
  /// Used to check if it is necessary to change state before updating game logic
  /// </summary>
  /// <param name="character"></param>
  public override void OnStatePreUpdate(Marco character)
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

    if (Input.GetButtonDown("Fire1"))
    {
      character.shootWeapon();
    }
    else if (Input.GetButtonDown("Fire2"))
    {
      character.throwBomb();
    }

    if(Input.GetAxisRaw("Vertical") > 0)
    {
      character.m_weaponSlot.transform.localRotation = Quaternion.Lerp(character.m_weaponSlot.transform.rotation, Quaternion.Euler(0, 0, 90), Time.time * 0.1f); 
    }
    else
    {
      character.m_weaponSlot.transform.localRotation = Quaternion.Lerp(character.m_weaponSlot.transform.rotation, Quaternion.Euler(0, 0, 0), Time.time * 0.1f);
    }
  }

  /// <summary>
  /// Logic update specific to this state
  /// </summary>
  /// <param name="character"></param>
  public override void OnStateUpdate(Marco character)
  {
    
  }

  /// <summary>
  /// Used to declare actions that will take place before exiting this state
  /// </summary>
  /// <param name="character"></param>
  public override void OnStateExit(Marco character) { }
}

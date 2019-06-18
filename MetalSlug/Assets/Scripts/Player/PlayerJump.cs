using System;
using UnityEngine;

public class PlayerJump : State<Player>
{

  public PlayerJump(StateMachine<Player> stateMachine)
  : base (stateMachine){  }

  public override void OnStateEnter(Player character)
  {
    Debug.Log("I'm jumping");
    character.m_isGrounded = false;
    character.m_horizontalSpeed = Input.GetAxisRaw("Horizontal") * Time.deltaTime * 5;
    character.GetComponent<Rigidbody2D>().AddForce(new Vector2(character.m_horizontalSpeed, 10), ForceMode2D.Impulse);
  }

  public override void OnStatePreUpdate(Player character)
  {
    if(character.GetComponent<Rigidbody2D>().velocity.y < 0)
    {
      m_StateMachine.ToState(character.playerFallState, character);
    }
  }

  public override void OnStateUpdate(Player character)
  {
    if (Input.GetAxisRaw("Horizontal") != 0)
    {

      Debug.Log("Changing direction in air");
      character.m_horizontalSpeed = Input.GetAxisRaw("Horizontal") * Time.deltaTime * character.m_speedMultiplier;
      character.GetComponent<Rigidbody2D>().AddForce(new Vector2(character.m_horizontalSpeed, 0), ForceMode2D.Impulse);

    }
  }

  public override void OnStateExit(Player character)
  {
    
  }
}

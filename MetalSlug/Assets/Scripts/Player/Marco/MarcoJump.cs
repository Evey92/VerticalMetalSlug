using System;
using UnityEngine;

public class MarcoJump : State<Marco>
{

  public MarcoJump(StateMachine<Marco> stateMachine)
  : base (stateMachine){  }

  public override void OnStateEnter(Marco character)
  {
    character.jump();
    character.IsJumping = true;
  }

  public override void OnStatePreUpdate(Marco character)
  {
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
  }

  public override void OnStateUpdate(Marco character)
  {
    if (Input.GetAxisRaw("Horizontal") != 0)
    {

      Debug.Log("Changing direction in air");
      character.m_horizontalSpeed = Input.GetAxisRaw("Horizontal") * Time.deltaTime * character.m_speedMultiplier;
      character.GetComponent<Rigidbody2D>().AddForce(new Vector2(character.m_horizontalSpeed, 0), ForceMode2D.Impulse);

    }
    if (character.GetComponent<Rigidbody2D>().velocity.y <=0)
    {
      m_StateMachine.ToState(character.playerFallState, character);
    }
  }

  public override void OnStateExit(Marco character)
  {
    
  }
}

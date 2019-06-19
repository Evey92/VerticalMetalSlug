using System;
using UnityEngine;

public class SlugJump : State<SlugTank>
{

  public SlugJump(StateMachine<SlugTank> stateMachine)
  : base (stateMachine){  }

  public override void OnStateEnter(SlugTank character)
  {
    Debug.Log("I'm jumping");
    character.IsGrounded = false;
    character.m_horizontalSpeed = Input.GetAxisRaw("Horizontal") * Time.deltaTime * 10;
    character.GetComponent<Rigidbody2D>().AddForce(new Vector2(character.m_horizontalSpeed, 10), ForceMode2D.Impulse);
  }

  public override void OnStatePreUpdate(SlugTank character)
  {
    if(character.GetComponent<Rigidbody2D>().velocity.y < 0)
    {
      m_StateMachine.ToState(character.slugFallState, character);
    }
    if (Input.GetButtonDown("Fire1"))
    {
      character.ShootWeapon();
    }
  }

  public override void OnStateUpdate(SlugTank character)
  {
    if (Input.GetAxisRaw("Horizontal") != 0)
    {

      Debug.Log("Changing direction in air");
      character.m_horizontalSpeed = Input.GetAxisRaw("Horizontal") * Time.deltaTime * character.m_speedMultiplier;
      character.GetComponent<Rigidbody2D>().AddForce(new Vector2(character.m_horizontalSpeed, 0), ForceMode2D.Impulse);

    }
  }

  public override void OnStateExit(SlugTank character)
  {
    
  }
}

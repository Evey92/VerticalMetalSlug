using System;
using UnityEngine;

public class MarcoFallState : State<Marco> 
{
  public MarcoFallState(StateMachine<Marco> stateMachine)
  : base(stateMachine) { }

  public override void OnStateEnter(Marco character)
  {
    Debug.Log("Entered Fall state");
    if(m_StateMachine.LastState == character.playerJumpState && Input.GetAxisRaw("Horizontal") != 0)
    {
      character.m_horizontalSpeed = Input.GetAxisRaw("Horizontal") * Time.deltaTime * character.m_hFallSpeed;
      character.GetComponent<Rigidbody2D>().AddForce(new Vector2(character.m_horizontalSpeed, 0), ForceMode2D.Impulse);
    }
    character.FallSpeed = 0;

  }

  public override void OnStatePreUpdate(Marco character)
  {
   if(character.IsGrounded)
    {
      m_StateMachine.ToState(character.playerIdleState, character);
    }

   if(Input.GetButtonDown("Fire1"))
    {
      character.shootWeapon();
    }

    if (Input.GetAxisRaw("Horizontal") != 0)
    {

      Debug.Log("Changing direction in air");
      character.m_horizontalSpeed += Input.GetAxisRaw("Horizontal") * Time.deltaTime * character.m_hFallSpeed;
      character.GetComponent<Rigidbody2D>().AddForce(new Vector2(character.m_horizontalSpeed, 0), ForceMode2D.Impulse);

    }
    

  }

  public override void OnStateUpdate(Marco character)
  {
    character.Fall();
  }

  public override void OnStateExit(Marco character)
  {
    character.FallSpeed = 0;

  }
}

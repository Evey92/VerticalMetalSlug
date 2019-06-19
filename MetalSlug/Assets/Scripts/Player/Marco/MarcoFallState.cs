using System;
using UnityEngine;

public class MarcoFallState : State<Marco> 
{
  public MarcoFallState(StateMachine<Marco> stateMachine)
  : base(stateMachine) { }

  public override void OnStateEnter(Marco character)
  {
    Debug.Log("Entered Fall state");

    // Play falling animation 
  }

  public override void OnStatePreUpdate(Marco character)
  {
   if(character.IsGrounded)
    {
      m_StateMachine.ToState(character.playerIdleState, character);
    }

   if(Input.GetButtonDown("Fire1"))
    {
      character.ShootWeapon();
    }
  }

  public override void OnStateUpdate(Marco character)
  {
    Vector3 vel = character.GetComponent<Rigidbody2D>().velocity;

    vel.y -= character.m_extraGravity * Time.deltaTime;

    character.GetComponent<Rigidbody2D>().velocity = vel;
  }

  public override void OnStateExit(Marco character)
  {
    
  }
}

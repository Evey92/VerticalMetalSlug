using System;
using UnityEngine;

public class SlugFallState : State<SlugTank> 
{
  public SlugFallState(StateMachine<SlugTank> stateMachine)
  : base(stateMachine) { }

  public override void OnStateEnter(SlugTank character)
  {
    Debug.Log("Entered Fall state");

    // Play falling animation 
  }

  public override void OnStatePreUpdate(SlugTank character)
  {
   if(character.IsGrounded)
    {
      m_StateMachine.ToState(character.slugIdleState, character);
    }

   if(Input.GetButtonDown("Fire1"))
    {
      character.shootWeapon();
    }
  }

  public override void OnStateUpdate(SlugTank character)
  {
    Vector3 vel = character.GetComponent<Rigidbody2D>().velocity;

    vel.y -= character.FallSpeed * Time.deltaTime;

    character.GetComponent<Rigidbody2D>().velocity = vel;
  }

  public override void OnStateExit(SlugTank character)
  {
    
  }
}

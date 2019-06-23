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
    Debug.Log("Entered Idle State");
    character.m_torsoAnimator.SetBool("isGrounded", true);
    character.m_legsAnimator.SetBool("isGrounded", true);

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

    if(!character.IsGrounded && !character.IsJumping)
    {
      m_StateMachine.ToState(character.playerFallState, character);
      character.IsGrounded = false;
    }

    if (Input.GetButtonDown("Fire1"))
    {
      character.m_torsoAnimator.SetBool("isShooting", true);
      character.m_torsoAnimator.SetTrigger("Shoot");
      character.shootWeapon();
    }

    else if (Input.GetButtonDown("Fire2"))
    {
      character.m_torsoAnimator.SetTrigger("Grenade");
      character.throwBomb();
    }

    if(Input.GetAxisRaw("Vertical") > 0)
    {
      character.m_weapon.m_bulletSpawn.transform.localRotation = Quaternion.Lerp(character.m_weapon.m_bulletSpawn.transform.localRotation, Quaternion.Euler(0, 0, 90), Time.fixedDeltaTime * character.m_guninterpolation);
      character.m_torsoAnimator.SetBool("isPointing", true);
      character.m_torsoAnimator.SetBool("isPointingUp", true);

    }
    else if(Input.GetAxis("Vertical") == 0)
    {
      character.m_weapon.m_bulletSpawn.transform.localRotation = Quaternion.Lerp(character.m_weapon.m_bulletSpawn.transform.localRotation, Quaternion.Euler(0, 0, 0), Time.fixedDeltaTime * character.m_guninterpolation);
      character.m_torsoAnimator.SetBool("isPointing", false);
      character.m_torsoAnimator.SetBool("isPointingUp", false);
      character.m_torsoAnimator.SetBool("isPointingDown", false);

    }

  }

  /// <summary>
  /// Logic update specific to this state
  /// </summary>
  /// <param name="character"></param>
  public override void OnStateUpdate(Marco character)
  {
    character.m_torsoAnimator.SetBool("isShooting", false);

  }

  /// <summary>
  /// Used to declare actions that will take place before exiting this state
  /// </summary>
  /// <param name="character"></param>
  public override void OnStateExit(Marco character)
  {

  }
}

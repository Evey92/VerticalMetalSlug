using System;
using UnityEngine;

public class MarcoWalk : State<Marco>
{

  public MarcoWalk(StateMachine<Marco> stateMachine)
  : base(stateMachine){ }

  public override void OnStateEnter(Marco character)
  {
    character.m_torsoAnimator.SetBool("isWalking", true);
    character.m_legsAnimator.SetBool("isWalking", true);
    character.m_isMoving = true;
  }

  public override void OnStatePreUpdate(Marco character)
  {
    if (Input.GetAxisRaw("Horizontal") == 0) 
    {
      m_StateMachine.ToState(character.playerIdleState, character);

    }
    else if(Input.GetAxisRaw("Horizontal") < 0)
    {
      character.transform.rotation = Quaternion.Euler(0, 180, 0);
      character.IsFacingRight = false;
    }
    else if (Input.GetAxisRaw("Horizontal") > 0)
    {
      character.transform.rotation = Quaternion.Euler(0, 0, 0);
      character.IsFacingRight = true;
    }

    if (Input.GetButtonDown("Jump"))
    {
      m_StateMachine.ToState(character.playerJumpState, character);
    }

    if (Input.GetAxisRaw("Vertical") > 0)
    {
      character.m_weapon.m_bulletSpawn.transform.localRotation = Quaternion.Lerp(character.m_weapon.m_bulletSpawn.transform.localRotation, Quaternion.Euler(0, 0, 90), Time.fixedDeltaTime * character.m_guninterpolation);
      character.m_torsoAnimator.SetBool("isPointing", true);
      character.m_torsoAnimator.SetBool("isPointingUp", true);

    }
    else if (Input.GetAxis("Vertical") == 0)
    {
      character.m_weapon.m_bulletSpawn.transform.localRotation = Quaternion.Lerp(character.m_weapon.m_bulletSpawn.transform.localRotation, Quaternion.Euler(0, 0, 0), Time.fixedDeltaTime * character.m_guninterpolation);
      character.m_torsoAnimator.SetBool("isPointing", false);
      character.m_torsoAnimator.SetBool("isPointingUp", false);

    }

    if (Input.GetButtonDown("Fire1"))
    {
      character.m_torsoAnimator.SetTrigger("Shoot");
      character.m_torsoAnimator.SetBool("isShooting", true);
      character.shootWeapon();
    }
    else if (Input.GetButtonDown("Fire2"))
    {
      character.m_torsoAnimator.SetTrigger("Grenade");
      character.throwBomb();
    }
    if (!character.IsGrounded)
    {
      m_StateMachine.ToState(character.playerFallState, character);
    }
  }

  public override void OnStateUpdate(Marco character)
  {
    character.walk();
    character.m_torsoAnimator.SetBool("isShooting", false);

  }

  public override void OnStateExit(Marco character)
  {
    character.m_torsoAnimator.SetBool("isWalking", false);
    character.m_legsAnimator.SetBool("isWalking", false);

    character.m_isMoving = false;

  }
}

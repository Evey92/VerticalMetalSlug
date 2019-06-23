using System;
using UnityEngine;

public class MarcoJump : State<Marco>
{

  public MarcoJump(StateMachine<Marco> stateMachine)
  : base (stateMachine){  }

  public override void OnStateEnter(Marco character)
  {
    Debug.Log("Jumping");
    character.m_torsoAnimator.SetBool("isGrounded", false);
    character.m_legsAnimator.SetBool("isGrounded", false);
    character.m_torsoAnimator.SetBool("isJumping", true);
    character.m_legsAnimator.SetBool("isJumping", true);

    character.IsJumping = true;
    character.CalculateInitialJumpSpeed();
  }

  public override void OnStatePreUpdate(Marco character)
  {
    

    

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
      character.m_torsoAnimator.SetBool("isPointingDown", false);

    }
    else if (Input.GetAxis("Vertical") < 0)
    {
      character.m_weapon.m_bulletSpawn.transform.localRotation = Quaternion.Lerp(character.m_weapon.m_bulletSpawn.transform.localRotation, Quaternion.Euler(0, 0, -90), Time.fixedDeltaTime * character.m_guninterpolation);
      character.m_torsoAnimator.SetBool("isPointing", true);
      character.m_torsoAnimator.SetBool("isPointingDown", true);

    }

    if (Input.GetButtonDown("Fire1"))
    {
      character.m_torsoAnimator.SetTrigger("Shoot");
      character.m_torsoAnimator.SetBool("isShooting",true);
      character.shootWeapon();
    }
    else if (Input.GetButtonDown("Fire2"))
    {
      character.m_torsoAnimator.SetTrigger("Grenade");
      character.throwBomb();
    }
    if (character.JumpSpeed <= 0)
    {
      m_StateMachine.ToState(character.playerFallState, character);

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
    character.Jump();
    character.IsGrounded = false;
    character.m_torsoAnimator.SetBool("isShooting", false);


  }

  public override void OnStateExit(Marco character)
  {
    character.m_torsoAnimator.SetBool("isJumping", false);
    character.m_legsAnimator.SetBool("isJumping", false);
    character.IsJumping = false;
  }
}

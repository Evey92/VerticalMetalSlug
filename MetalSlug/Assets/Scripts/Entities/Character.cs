using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Character : Entity
{
#region Unity
  protected override void OnTriggerEnter2D(Collider2D other)
  {
    base.OnTriggerEnter2D(other);
    if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
    {
      m_canJump = true;
    }
  }

  protected override void OnTriggerExit2D(Collider2D other)
  {
    base.OnTriggerExit2D(other);
    if (other.gameObject.layer == 1 << LayerMask.NameToLayer("Ground"))
    {
      m_canJump = false;
    }
  }
#endregion

#region Methods
  /// <summary>
  /// Used to calculate initial speed for jumping
  /// </summary>
  public void CalculateInitialJumpSpeed()
  {
    m_jumpSpeed = (0.5f) * (1.0f - Mathf.Sqrt((4.0f * -m_gravity * m_jumpTime) - (8.0f * -m_gravity * m_jumpHeight) + 1.0f));
    if (m_jumpSpeed < 0.0f)
    {
      m_jumpSpeed = (0.5f) * (Mathf.Sqrt((4.0f * -m_gravity * m_jumpTime) - (8.0f * -m_gravity * m_jumpHeight) + 1.0f) + 1.0f);
    }
  }

  /// <summary>
  /// Used to calculate and apply JumpSpeed.
  /// Should be called on Jump states' Update methods.
  /// </summary>
  public virtual void Jump()
  {
    m_jumpSpeed -= Gravity * Time.fixedDeltaTime;
    transform.position = new Vector3(transform.position.x,
      transform.position.y + m_jumpSpeed * Time.fixedDeltaTime,
      transform.position.z);
  }
#endregion

#region Gizmos
  protected virtual void OnDrawGizmos()
  {
    Vector3 jumpStart, jumpEnd;
    if (m_isJumping)
    {
      jumpStart = new Vector3(transform.position.x - 0.1f,
        m_jumpStartPosition,
        transform.position.z);
      jumpEnd = new Vector3(transform.position.x - 0.1f,
        m_jumpStartPosition + m_jumpHeight,
        transform.position.z);
    }
    else
    {
      jumpStart = new Vector3(transform.position.x - 0.1f,
        transform.position.y,
        transform.position.z);
      jumpEnd = new Vector3(transform.position.x - 0.1f,
        transform.position.y + m_jumpHeight,
        transform.position.z);
    }
    Gizmos.color = Color.green;
    Gizmos.DrawLine(jumpStart, jumpEnd);
  }
#endregion

#region Private Members
  /// <summary>
  /// Whether character is currently jumping
  /// </summary>
  protected bool m_isJumping;

  /// <summary>
  /// Whether character can jump
  /// </summary>
  protected bool m_canJump;

  /// <summary>
  /// Position where jump started
  /// </summary>
  protected float m_jumpStartPosition;

  /// <summary>
  /// Used to calculate position when jumping
  /// </summary>
  protected float m_jumpSpeed;
#endregion

#region Editor Members
  /// <summary>
  /// Sets the height for the jump
  /// </summary>
  [SerializeField]
  [Range(3.0f, 6.0f)]
  [Tooltip("Jump height.")]
  protected float m_jumpHeight = 3.0f;

  /// <summary>
  /// Sets the time it'll take to reach jump height
  /// </summary>
  [SerializeField]
  [Range(0.5f, 1.0f)]
  [Tooltip("Time it'll take to reach the jump height in seconds.")]
  protected float m_jumpTime = 0.5f;
#endregion

#region Properties
  /// <summary>
  /// 
  /// </summary>
  public bool IsJumping
  {
    set { m_isJumping = value; }
    get { return m_isJumping; }
  }

  /// <summary>
  /// 
  /// </summary>
  public bool CanJump
  {
    set { m_canJump = value; }
    get { return m_canJump; }
  }

  /// <summary>
  /// 
  /// </summary>
  public float JumpStartPosition
  {
    set { m_jumpStartPosition = value; }
    get { return m_jumpStartPosition; }
  }

  /// <summary>
  /// 
  /// </summary>
  public float JumpSpeed
  {
    set { m_jumpSpeed = value; }
    get { return m_jumpSpeed; }
  }

  /// <summary>
  /// 
  /// </summary>
  public float JumpHeight { get { return m_jumpHeight; } }

  /// <summary>
  /// 
  /// </summary>
  public float JumpTime { get { return m_jumpTime; } }
#endregion
}

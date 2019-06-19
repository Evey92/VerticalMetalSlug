using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
#region Unity

#endregion

#region Methods
  protected abstract void InitStateMachine();
#endregion

#region Gizmos

#endregion

#region Private Members
  /// <summary>
  /// Whether entity is touching the ground
  /// </summary>
  protected bool m_isGrounded;

  /// <summary>
  /// Whether entity is facing its right
  /// </summary>
  protected bool m_isFacingRight;

  /// <summary>
  /// Entity's walk speed
  /// </summary>
  protected float m_walkSpeed;

  /// <summary>
  /// Entity's speed when falling
  /// </summary>
  protected float m_fallSpeed;
  #endregion

  #region Editor Members
  /// <summary>
  /// Entity's gravity, used to calculate its speed when falling
  /// </summary>
  [SerializeField]
  [Range(0.0f, 9.8f)]
  protected float m_gravity;
#endregion

#region Properties
  /// <summary>
  /// Public getter and setter for m_isGrounded
  /// </summary>
  public bool IsGrounded
  {
    set { m_isGrounded = value; }
    get { return m_isGrounded; }
  }

  /// <summary>
  /// Public getter and setter for m_isFacingRight
  /// </summary>
  public bool IsFacingRight {
    set { m_isFacingRight = value; }
    get { return m_isFacingRight; }
  }

  /// <summary>
  /// Public getter and setter for m_walkSpeed
  /// </summary>
  public float WalkSpeed
  {
    set { m_walkSpeed = value; }
    get { return m_walkSpeed; }
  }

  /// <summary>
  /// Public getter and setter for m_fallSpeed
  /// </summary>
  public float FallSpeed
  {
    set { m_fallSpeed = value; }
    get { return m_fallSpeed; }
  }

  /// <summary>
  /// Public getter for m_gravity
  /// </summary>
  public float Gravity { get { return m_gravity; } }
#endregion
}

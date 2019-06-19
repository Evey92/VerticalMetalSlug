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

#endregion

#region Properties
  /// <summary>
  /// Public getter for m_isGrounded
  /// </summary>
  public bool IsGrounded { get { return m_isGrounded; } }

  /// <summary>
  /// Public getter for m_isFacingRight
  /// </summary>
  public bool IsFacingRight { get { return m_isFacingRight; } }

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
#endregion
}

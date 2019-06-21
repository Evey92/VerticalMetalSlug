using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
#region Unity
  protected virtual void OnTriggerEnter2D(Collider2D other)
  {
    RaycastHit2D hit = Physics2D.Raycast(transform.position,
      -transform.up,
      Mathf.Infinity,
      (1 << LayerMask.NameToLayer("Ground")));
    if (hit.collider != null)
    {
      float distance = Mathf.Abs((transform.position.y - (GetComponent<Collider2D>().bounds.size.y / 2)) - hit.point.y);
      transform.position = new Vector3(transform.position.x,
        hit.point.y + (GetComponent<Collider2D>().bounds.size.y / 2),
        transform.position.z);
      m_isGrounded = true;
    }
  }

  protected virtual void OnTriggerStay2D(Collider2D other)
  {
    RaycastHit2D hit = Physics2D.Raycast(transform.position,
       -transform.up,
       Mathf.Infinity,
       (1 << LayerMask.NameToLayer("Ground")));
    if (hit.collider != null)
    {
      float distance = Mathf.Abs((transform.position.y - (GetComponent<Collider2D>().bounds.size.y / 2)) - hit.point.y);
      if (hit.point.y > (transform.position.y - (GetComponent<Collider2D>().bounds.size.y / 2)))
      {
        transform.position = new Vector3(transform.position.x,
          hit.point.y + (GetComponent<Collider2D>().bounds.size.y / 2),
          transform.position.z);
      }
    }
    else
    {
      m_isGrounded = false;
    }
  }

  protected virtual void OnTriggerExit2D(Collider2D other)
  {
    if (m_isGrounded && other.gameObject.layer == LayerMask.NameToLayer("Ground"))
    {
      m_isGrounded = false;
    }
  }
#endregion

#region Methods
  protected abstract void InitStateMachine();

  /// <summary>
  /// Used to calculate fall speed and apply it to this entity's position.
  /// Should be called on fall states.
  /// </summary>
  public virtual void Fall()
  {
    m_fallSpeed += m_gravity * Time.fixedDeltaTime;
    transform.position = new Vector3(transform.position.x,
      transform.position.y - (m_fallSpeed * Time.fixedDeltaTime),
      transform.position.z);
  }
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
  /// Entity's speed when falling
  /// </summary>
  protected float m_fallSpeed;
#endregion

#region Editor Members
  /// <summary>
  /// Entity's walk speed
  /// </summary>
  [SerializeField]
  [Range(3.0f, 6.0f)]
  protected float m_walkSpeed = 3.0f;

  /// <summary>
  /// Entity's gravity, used to calculate its speed when falling
  /// </summary>
  [SerializeField]
  [Range(0.0f, 9.8f)]
  protected float m_gravity = 9.8f;
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

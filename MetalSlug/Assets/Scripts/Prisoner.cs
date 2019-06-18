using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrisonerState
{
  public enum E
  {
    kSitting = 0,
    kStanding,
    kHanging
  };
}

public class Prisoner : MonoBehaviour
{
#region Unity
  private void Awake()
  {
    InitStateMachine();

    m_startPosition = transform.position.x;
    m_endPosition = m_startPosition + m_walkingRange;

    m_isPathSet = true;

    if (m_prisonerState == PrisonerState.E.kHanging)
    {
      m_isGrounded = false;
    }
    else
    {
      m_isGrounded = true;
    }
  }

  private void FixedUpdate()
  {
    m_StateMachine.OnState(this);
  }
#endregion

#region Methods
  /// <summary>
  /// 
  /// </summary>
  private void InitStateMachine()
  {
    m_StateMachine = new StateMachine<Prisoner>();

    prisonerCaptured = new PrisonerCaptured(m_StateMachine);
    prisonerFalling = new PrisonerFalling(m_StateMachine);
    prisonerFleeing = new PrisonerFleeing(m_StateMachine);
    prisonerRescued = new PrisonerRescued(m_StateMachine);
    prisonerWalk = new PrisonerWalk(m_StateMachine);

    m_StateMachine.Init(prisonerWalk, this);
  }
#endregion

#region Gizmos
  private void OnDrawGizmos()
  {
    Vector3 startPosition;
    Vector3 endPosition;
    if (IsPathSet)
    {
      startPosition = new Vector3(StartPosition,
        transform.position.y,
        transform.position.z);
      endPosition = new Vector3(EndPosition,
        transform.position.y,
        transform.position.z);
    }
    else
    {
      startPosition = new Vector3(transform.position.x,
        transform.position.y,
        transform.position.z);
      endPosition = new Vector3(transform.position.x + m_walkingRange,
        transform.position.y,
        transform.position.z);
    }
    Gizmos.color = Color.blue;
    Gizmos.DrawLine(startPosition, endPosition);
  }
#endregion

#region Private Members
  private float m_startPosition;
  private float m_endPosition;
  private float m_fallSpeed;
  private bool m_isPathSet = false;
  [SerializeField]
  private bool m_isGrounded;
  private bool m_walkRight = true;
#endregion

#region Public Members
  public PrisonerState.E m_prisonerState;
  [Range(10, 1000)]
  public float m_walkingRange = 10;
  [Range(5, 10)]
  public float m_walkingSpeed = 5;
  [Range(10, 20)]
  public float m_fleeingSpeed = 10;
#endregion

#region Properties
  public float StartPosition { get { return m_startPosition; } }
  public float EndPosition { get { return m_endPosition; } }
  public float FallSpeed
  {
    set { m_fallSpeed = value; }
    get { return m_fallSpeed; }
  }
  public bool WalkRight
  {
    set { m_walkRight = value; }
    get { return m_walkRight; }
  }
  public bool IsPathSet { get { return m_isPathSet; } }
  public bool IsGrounded { get { return m_isGrounded; } }
#endregion

#region State Machine
  /// <summary>
  /// 
  /// </summary>
  private StateMachine<Prisoner> m_StateMachine;

#region States
  /// <summary>
  /// 
  /// </summary>
  public PrisonerCaptured prisonerCaptured;

  /// <summary>
  /// 
  /// </summary>
  public PrisonerFalling prisonerFalling;

  /// <summary>
  /// 
  /// </summary>
  public PrisonerFleeing prisonerFleeing;

  /// <summary>
  /// 
  /// </summary>
  public PrisonerRescued prisonerRescued;

  /// <summary>
  /// 
  /// </summary>
  public PrisonerWalk prisonerWalk;
#endregion
#endregion
}

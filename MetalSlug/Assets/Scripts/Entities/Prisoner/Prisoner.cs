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

public class Prisoner : Entity
{
#region Unity
  private void Awake()
  {
    InitStateMachine();

    m_startPosition = transform.position.x;
    if (m_startRight)
    {
      m_endPosition = m_startPosition + m_walkRange;
      m_isFacingRight = true;
    }
    else
    {
      m_endPosition = m_startPosition - m_walkRange;
      m_isFacingRight = false;
    }

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
  protected override void InitStateMachine()
  {
    m_StateMachine = new StateMachine<Prisoner>();

    prisonerCaptured = new PrisonerCaptured(m_StateMachine);
    prisonerFalling = new PrisonerFalling(m_StateMachine);
    prisonerFleeing = new PrisonerFleeing(m_StateMachine);
    prisonerRescued = new PrisonerRescued(m_StateMachine);
    prisonerWalk = new PrisonerWalk(m_StateMachine);

    m_StateMachine.Init(prisonerCaptured, this);
  }
#endregion

#region Gizmos
  private void OnDrawGizmos()
  {
    Vector3 startPosition;
    Vector3 endPosition;
    if (m_isPathSet)
    {
      startPosition = new Vector3(m_startPosition,
        transform.position.y,
        transform.position.z);
      endPosition = new Vector3(m_endPosition,
        transform.position.y,
        transform.position.z);
    }
    else
    {
      if (m_startRight)
      {
        startPosition = new Vector3(transform.position.x,
          transform.position.y,
          transform.position.z);
        endPosition = new Vector3(transform.position.x + m_walkRange,
          transform.position.y,
          transform.position.z);
      }
      else
      {
        startPosition = new Vector3(transform.position.x,
          transform.position.y,
          transform.position.z);
        endPosition = new Vector3(transform.position.x - m_walkRange,
          transform.position.y,
          transform.position.z);
      }
    }
    Gizmos.color = Color.blue;
    Gizmos.DrawLine(startPosition, endPosition);
  }
#endregion

#region Private Members
  private float m_startPosition;
  private float m_endPosition;
  private bool m_isPathSet = false;
  private bool m_isFree = false;
  private bool m_droppedItem = false;
#endregion

#region Editor Members
  [SerializeField]
  private PrisonerState.E m_prisonerState;
  [SerializeField]
  [Range(5, 20)]
  private float m_walkRange = 10;
  [SerializeField]
  [Range(10, 20)]
  private float m_fleeSpeed = 10;
  [SerializeField]
  private bool m_startRight;
#endregion

#region Properties
  public float StartPosition { get { return m_startPosition; } }
  public float EndPosition { get { return m_endPosition; } }
  public bool IsPathSet { get { return m_isPathSet; } }
  public bool IsFree { get { return m_isFree; } }
  public bool DroppedItem { get { return m_droppedItem; } }
  // TODO: Add a boolean for whether the prisoner should start running right
  // TODO: Add a walk speed slider for the editor

  public PrisonerState.E CapturedState { get { return m_prisonerState; } }
  public float WalkRange { get { return m_walkRange; } }
  public float FleeSpeed { get { return m_fleeSpeed; } }
  public bool StartRight { get { return m_startRight; } }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prisoner : MonoBehaviour
{
  private void Awake()
  {
    InitStateMachine();
  }

  private void FixedUpdate()
  {
    m_StateMachine.OnState(this);
  }

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

    m_StateMachine.Init(prisonerCaptured);
  }

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

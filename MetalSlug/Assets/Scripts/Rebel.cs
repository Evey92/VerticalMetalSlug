using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebel : Enemy
{
#region Unity
  private void Awake()
  {
    InitStateMachine();
  }
#endregion

#region Methods
  protected override void InitStateMachine()
  {
    m_StateMachine = new StateMachine<Rebel>();

    rebelDie = new RebelDie(m_StateMachine);
    rebelFall = new RebelFall(m_StateMachine);
    rebelFlee = new RebelFlee(m_StateMachine);
    rebelIdle = new RebelIdle(m_StateMachine);
    rebelJumping = new RebelJumping(m_StateMachine);
    rebelWalk = new RebelWalk(m_StateMachine);
  }
#endregion

#region Gizmos

#endregion

#region Private Members

#endregion

#region Editor Members

#endregion

#region Properties

#endregion

#region State Machine
  /// <summary>
  /// 
  /// </summary>
  private StateMachine<Rebel> m_StateMachine;

#region States
  /// <summary>
  /// 
  /// </summary>
  public RebelDie rebelDie;

  /// <summary>
  /// 
  /// </summary>
  public RebelFall rebelFall;

  /// <summary>
  /// 
  /// </summary>
  public RebelFlee rebelFlee;

  /// <summary>
  /// 
  /// </summary>
  public RebelIdle rebelIdle;

  /// <summary>
  /// 
  /// </summary>
  public RebelJumping rebelJumping;

  /// <summary>
  /// 
  /// </summary>
  public RebelWalk rebelWalk;
#endregion
#endregion
}

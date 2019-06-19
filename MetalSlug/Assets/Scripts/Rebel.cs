using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RebelInitialState
{
  public enum E
  {
    kIdle = 0,
    kCrawl,
    kRun,
    kAmbush,

    kNum
  };
}

public class Rebel : Enemy
{
#region Unity
  private void Awake()
  {
    InitStateMachine();

    m_HP = 1.0f;
  }
#endregion

#region Methods
  protected override void InitStateMachine()
  {
    m_StateMachine = new StateMachine<Rebel>();

    rebelAmbush = new RebelAmbush(m_StateMachine);
    rebelCrawl = new RebelCrawl(m_StateMachine);
    rebelDie = new RebelDie(m_StateMachine);
    rebelFall = new RebelFall(m_StateMachine);
    rebelFlee = new RebelFlee(m_StateMachine);
    rebelIdle = new RebelIdle(m_StateMachine);
    rebelJumping = new RebelJumping(m_StateMachine);
    rebelRun = new RebelRun(m_StateMachine);
    rebelWalk = new RebelWalk(m_StateMachine);

    switch (m_initialState)
    {
      case RebelInitialState.E.kIdle:
        m_StateMachine.Init(rebelIdle, this);
        break;
      case RebelInitialState.E.kCrawl:
        m_StateMachine.Init(rebelCrawl, this);
        break;
      case RebelInitialState.E.kRun:
        m_StateMachine.Init(rebelRun, this);
        break;
      case RebelInitialState.E.kAmbush:
        m_StateMachine.Init(rebelAmbush, this);
        break;
      default:
        m_StateMachine.Init(rebelIdle, this);
        break;
    }
  }
#endregion

#region Gizmos

#endregion

#region Private Members
  
#endregion

#region Editor Members
  /// <summary>
  /// 
  /// </summary>
  [SerializeField]
  protected RebelInitialState.E m_initialState;

  /// <summary>
  /// 
  /// </summary>
  protected float m_runSpeed;

  /// <summary>
  /// 
  /// </summary>
  protected float m_jumpHeight;

  /// <summary>
  /// 
  /// </summary>
  protected float m_ambushHeight;
#endregion

#region Properties
  /// <summary>
  /// 
  /// </summary>
  public RebelInitialState.E InitialState { get { return m_initialState; } }

  /// <summary>
  /// 
  /// </summary>
  public float RunSpeed { get { return m_runSpeed; } }

  /// <summary>
  /// 
  /// </summary>
  public float JumpHeight { get { return m_jumpHeight; } }

  /// <summary>
  /// 
  /// </summary>
  public float AmbushHeight { get { return m_ambushHeight; } }
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
  public RebelAmbush rebelAmbush;

  /// <summary>
  /// 
  /// </summary>
  public RebelCrawl rebelCrawl;

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
  public RebelRun rebelRun;

  /// <summary>
  /// 
  /// </summary>
  public RebelWalk rebelWalk;
#endregion
#endregion
}

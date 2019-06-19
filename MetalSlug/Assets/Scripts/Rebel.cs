using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
      case RebelInitialState.E.kNum: // Should not really be set to this, but in case it is
        m_StateMachine.Init(rebelIdle, this);
        break;
      default:
        m_StateMachine.Init(rebelIdle, this);
        break;
    }

    m_StateMachine.Init(rebelJumping, this);
  }

  /// <summary>
  /// 
  /// </summary>
  public void CalculateInitialJumpSpeed()
  {
    m_jumpSpeed = (1.0f / 2.0f) * (1.0f - (float)Math.Sqrt((4.0f * -m_gravity * m_jumpTime) - (8.0f * -m_gravity * m_jumpHeight) + 1.0f));
    if (m_jumpSpeed < 0.0f)
    {
      m_jumpSpeed = (1.0f / 2.0f) * ((float)Math.Sqrt((4.0f * -m_gravity * m_jumpTime) - (8.0f * -m_gravity * m_jumpHeight) + 1.0f) + 1.0f);
    }
  }
#endregion

#region Gizmos
  private void OnDrawGizmos()
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
  /// 
  /// </summary>
  [SerializeField]
  protected bool m_isJumping;

  /// <summary>
  /// 
  /// </summary>
  protected float m_jumpStartPosition;

  /// <summary>
  /// 
  /// </summary>
  protected float m_jumpSpeed;
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
  [SerializeField]
  [Range(5.0f, 10.0f)]
  protected float m_runSpeed;

  /// <summary>
  /// 
  /// </summary>
  [SerializeField]
  [Range(10.0f, 20.0f)]
  protected float m_fleeSpeed;

  /// <summary>
  /// 
  /// </summary>
  [SerializeField]
  [Range(3.0f, 6.0f)]
  protected float m_jumpHeight;

  /// <summary>
  /// 
  /// </summary>
  [SerializeField]
  [Range(0.5f, 1.0f)]
  protected float m_jumpTime;

  /// <summary>
  /// 
  /// </summary>
  [SerializeField]
  [Range(6.0f, 12.0f)]
  protected float m_ambushHeight;
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
  public float JumpStartPosition
  {
    set { m_jumpStartPosition = value; }
    get { return m_jumpStartPosition; }
  }

  public float JumpSpeed
  {
    set { m_jumpSpeed = value; }
    get { return m_jumpSpeed; }
  }

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
  public float FleeSpeed { get { return m_fleeSpeed; } }

  /// <summary>
  /// 
  /// </summary>
  public float JumpHeight { get { return m_jumpHeight; } }

  /// <summary>
  /// 
  /// </summary>
  public float JumpTime { get { return m_jumpTime; } }

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

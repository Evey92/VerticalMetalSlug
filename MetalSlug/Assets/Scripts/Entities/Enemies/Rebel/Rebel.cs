using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

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
  protected override void Awake()
  {
    base.Awake();

    InitStateMachine();

    m_HP = 1.0f;
  }

  protected override void FixedUpdate()
  {
    base.FixedUpdate();

    if (m_nearestPlayer != null)
    {
      float distance = Vector3.Distance(transform.position, m_nearestPlayer.transform.position);
      //if (m_canTurn && m_isGrounded && (distance < m_playerDetectRadius))
      //{
      //  if (m_nearestPlayer.transform.position.x < transform.position.x)
      //  {
      //    if (!m_isFacingRight)
      //      m_isFacingRight = true;
      //  }
      //  else
      //  {
      //    if (m_isFacingRight)
      //      m_isFacingRight = false;
      //  }
      //}
    } 

    m_StateMachine.OnState(this);
  }

  protected void OnTriggerEnter2D(Collider2D other)
  {
    //base.OnTriggerEnter2D(other);

    if (other.gameObject.layer == LayerMask.NameToLayer("PlayerBullet"))
    {
      m_HP = 0;
    }
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
    rebelThrow = new RebelThrow(m_StateMachine);
    rebelTipToe = new RebelTipToe(m_StateMachine);
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
  }

  public void Die()
  {
    Destroy(gameObject);
  }
#endregion

#region Gizmos
  protected override void OnDrawGizmos()
  {
    base.OnDrawGizmos();

    Handles.color = Color.yellow;
    Handles.DrawWireDisc(transform.position,
      new Vector3(0, 0, 1),
      m_playerDetectRadius);

    Handles.color = Color.red;
    Handles.DrawWireDisc(transform.position,
      new Vector3(0, 0, 1),
      m_threatRadius);

    Gizmos.color = Color.blue;
    if(m_isFacingRight)
    {
      Gizmos.DrawLine(new Vector3(transform.position.x - m_playerDetectRadius,
        transform.position.y,
        transform.position.z),
        new Vector3(transform.position.x - m_playerDetectRadius - m_safeZone,
        transform.position.y,
        transform.position.z));
    }
    else
    {
      Gizmos.DrawLine(new Vector3(transform.position.x + m_playerDetectRadius,
        transform.position.y,
        transform.position.z),
        new Vector3(transform.position.x + m_playerDetectRadius + m_safeZone,
        transform.position.y,
        transform.position.z));
    }
  }
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
  [SerializeField]
  [Range(0.5f, 2.5f)]
  protected float m_crawlSpeed = 0.5f;

  /// <summary>
  /// 
  /// </summary>
  [SerializeField]
  [Range(2.5f, 5.0f)]
  protected float m_tipToeSpeed = 2.5f;

  /// <summary>
  /// 
  /// </summary>
  [SerializeField]
  [Range(5.0f, 10.0f)]
  protected float m_runSpeed = 5.0f;

  /// <summary>
  /// 
  /// </summary>
  [SerializeField]
  [Range(10.0f, 20.0f)]
  protected float m_fleeSpeed = 10.0f;

  /// <summary>
  /// 
  /// </summary>
  [SerializeField]
  [Range(6.0f, 12.0f)]
  protected float m_ambushHeight = 6.0f;

  /// <summary>
  /// 
  /// </summary>
  [SerializeField]
  [Range(5.0f, 8.0f)]
  protected float m_playerDetectRadius = 5.0f;

  /// <summary>
  /// 
  /// </summary>
  [SerializeField]
  [Range(1.0f, 3.0f)]
  protected float m_threatRadius = 1.0f;

  /// <summary>
  /// 
  /// </summary>
  [SerializeField]
  [Range(2.0f, 4.0f)]
  protected float m_safeZone = 2.0f;

  /// <summary>
  /// 
  /// </summary>
  [SerializeField]
  [Range(0.5f, 2.0f)]
  protected float m_timeToTurn = 0.5f;
#endregion

#region Properties
  /// <summary>
  /// 
  /// </summary>
  public RebelInitialState.E InitialState { get { return m_initialState; } }

  /// <summary>
  /// 
  /// </summary>
  public float CrawlSpeed { get { return m_crawlSpeed; } }

  /// <summary>
  /// 
  /// </summary>
  public float TipToeSpeed { get { return m_tipToeSpeed; } }

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
  public float AmbushHeight { get { return m_ambushHeight; } }

  /// <summary>
  /// 
  /// </summary>
  public float PlayerDetectRadius { get { return m_playerDetectRadius; } }

  /// <summary>
  /// 
  /// </summary>
  public float ThreatRadius { get { return m_threatRadius; } }

  /// <summary>
  /// 
  /// </summary>
  public float SafeZone { get { return m_safeZone; } }

  /// <summary>
  /// 
  /// </summary>
  public float TimeToTurn { get { return m_timeToTurn; } }
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
  public RebelThrow rebelThrow;

  /// <summary>
  /// 
  /// </summary>
  public RebelTipToe rebelTipToe;

  /// <summary>
  /// 
  /// </summary>
  public RebelWalk rebelWalk;
#endregion
#endregion
}

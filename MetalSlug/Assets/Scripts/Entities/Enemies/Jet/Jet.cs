using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class Jet : Enemy
{
  #region Unity
  protected override void Awake()
  {
    base.Awake();
    InitStateMachine();
    m_HP = 100.0f;
  }

  public GameObject newbomb;

  protected override void FixedUpdate()
  {
    base.FixedUpdate();

    m_StateMachine.OnState(this);
  }

  protected override void OnCollisionEnter2D(Collision2D other)
  {
    base.OnCollisionEnter2D(other);

    if (other.gameObject.layer == LayerMask.NameToLayer("PlayerBullet"))
    {
      --m_HP;
      if(m_HP <= 0)
      {
        Destroy(gameObject);
      }
    }
    if(newbomb.transform.position.y >= NearestPlayer.transform.position.y)
    {
      //Destroy(newbomb);
      newbomb.GetComponentInChildren<ParticleSystem>().Play();
    }
  }
  #endregion

  #region Methods
  /// <summary>
  /// 
  /// </summary>
  protected override void InitStateMachine()
  {
    m_StateMachine = new StateMachine<Jet>();

    jetflying = new JetFlying(m_StateMachine);
    jetwaiting = new JetWaiting(m_StateMachine);
    jetflee = new JetFlee(m_StateMachine);
    jetshoot = new JetShooting(m_StateMachine);
    jetdie = new JetSDie(m_StateMachine);

    m_StateMachine.Init(jetwaiting, this);
  }

  public void Die()
  {
    Destroy(gameObject);
  }

  public void JETShoot()
  {
    newbomb = Instantiate(newbomb);
    newbomb.transform.Translate(newbomb.transform.position.x, newbomb.transform.position.y - m_walkSpeed * Time.fixedDeltaTime,
      newbomb.transform.position.z);
    --m_ammo;
    ++m_bombsonscreen;
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
  }
  #endregion

  #region Private Members
  private float m_timesfired = 0.0f;
  public int m_bombsonscreen = 0;
  private JetBomb m_bomb;
  #endregion

  #region Editor Members

  [SerializeField]
  protected Animator m_anim;
  [SerializeField]
  protected int m_ammo;
  [SerializeField]
  [Range(5.0f, 8.0f)]
  protected float m_playerDetectRadius = 5.0f;
  #endregion

  #region Properties
  public Animator Anim { get { return m_anim; } }
  public float TimesFired { get { return m_timesfired; } }
  public int Ammo { get { return m_ammo; } }
  public int BombOnScreen { get { return m_bombsonscreen; } }
  public JetBomb JetBombs { get { return m_bomb; } }
  public float PlayerDetectRadius { get { return m_playerDetectRadius; } }
  #endregion

  #region State Machine
  /// <summary>
  /// 
  /// </summary>
  private StateMachine<Jet> m_StateMachine;

  #region States

  ///<summary>
  ///
  ///</summary>
  public JetFlying jetflying;

  ///<summary>
  ///
  ///</summary>
  public JetWaiting jetwaiting;

  ///<summary>
  ///
  ///</summary>
  public JetFlee jetflee;

  ///<summary>
  ///
  ///</summary>
  public JetShooting jetshoot;

  ///<summary>
  ///
  ///</summary>
  public JetSDie jetdie;

  #endregion
  #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character
{
#region Unity
  protected virtual void Awake()
  {
    m_players = GameObject.FindGameObjectsWithTag("Player");
    m_nearestPlayer = m_players[0];
  }

  protected virtual void FixedUpdate()
  {
    SelectNearestPlayer();
  }
#endregion

#region Methods
  protected virtual void SelectNearestPlayer()
  {
    float distance = Vector3.Distance(transform.position, m_nearestPlayer.transform.position);
    foreach (GameObject player in m_players)
    {
      if (Vector3.Distance(transform.position,
        player.transform.position) < distance)
      {
        if (m_nearestPlayer != player)
        {
          m_nearestPlayer = player;
        }
      }
    }
  }
#endregion

#region Gizmos

#endregion

#region Private Members
  /// <summary>
  /// 
  /// </summary>
  protected GameObject[] m_players;

  /// <summary>
  /// 
  /// </summary>
  protected GameObject m_nearestPlayer;
#endregion

#region Editor Members
  /// <summary>
  /// 
  /// </summary>
  [SerializeField]
  protected float m_HP = 0;

  /// <summary>
  /// 
  /// </summary>
  [SerializeField]
  protected bool m_canTurn = true;
#endregion

#region Properties
  /// <summary>
  /// 
  /// </summary>
  public GameObject[] Players { get { return m_players; } }

  /// <summary>
  /// 
  /// </summary>
  public GameObject NearestPlayer { get { return m_nearestPlayer; } }

  /// <summary>
  /// 
  /// </summary>
  public float HP { get { return m_HP; } }

  /// <summary>
  /// 
  /// </summary>
  public bool CanTurn { get { return m_canTurn; } }
#endregion
}

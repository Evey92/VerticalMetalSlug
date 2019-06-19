using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  private void Awake()
  {
    InitStateMachine();
  }

  private void InitStateMachine()
  {
    m_StateMachine = new StateMachine<Enemy>();

    enemyDie = new EnemyDie(m_StateMachine);
    enemyFall = new EnemyFall(m_StateMachine);
    enemyFlee = new EnemyFlee(m_StateMachine);
    enemyIdle = new EnemyIdle(m_StateMachine);
    enemyJumping = new EnemyJumping(m_StateMachine);
    enemyWalk = new EnemyWalk(m_StateMachine);
  }

#region State Machine
  /// <summary>
  /// 
  /// </summary>
  private StateMachine<Enemy> m_StateMachine;

#region States
  /// <summary>
  /// 
  /// </summary>
  public EnemyDie enemyDie;

  /// <summary>
  /// 
  /// </summary>
  public EnemyFall enemyFall;

  /// <summary>
  /// 
  /// </summary>
  public EnemyFlee enemyFlee;

  /// <summary>
  /// 
  /// </summary>
  public EnemyIdle enemyIdle;

  /// <summary>
  /// 
  /// </summary>
  public EnemyJumping enemyJumping;

  /// <summary>
  /// 
  /// </summary>
  public EnemyWalk enemyWalk;
#endregion
#endregion
}

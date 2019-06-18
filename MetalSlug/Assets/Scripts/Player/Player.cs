using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

  // Start is called before the first frame update
  private void Awake()
  {
    
    InitStateMAchine();
    m_walkSpeed = 3;
    m_speedMultiplier = 5;
    
  }

  private void FixedUpdate()
  {
    m_playerStateMachine.OnState(this);
  }

  // Update is called once per frame
  void Update()
  {

  }

  /// <summary>
  /// Used to initiate the player's state machine
  /// </summary>
  private void InitStateMAchine()
  {
    m_playerStateMachine = new StateMachine<Player>();
    playerIdleState = new PlayerIdle(m_playerStateMachine);
    playerWalkState = new PlayerWalk(m_playerStateMachine);
    playerJumpState = new PlayerJump(m_playerStateMachine);
    playerFallState = new PlayerFallState(m_playerStateMachine);

    m_playerStateMachine.Init(playerIdleState);
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if(collision.gameObject.tag == "Floor" && !m_isGrounded)
    {
      m_isGrounded = true;
      Debug.Log("im grounded");
    }
  }

  public PlayerIdle playerIdleState;
  public PlayerWalk playerWalkState;
  public PlayerJump playerJumpState;
  public PlayerFallState playerFallState;
  public bool m_isGrounded;
  public float m_walkSpeed;
  public float m_speedMultiplier;
  public float m_horizontalSpeed;

  private StateMachine<Player> m_playerStateMachine;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

  private void Awake()
  {
    m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    m_thisCamera = GetComponent<Camera>();
  }

  void LateUpdate()
  {
    if (m_player.m_isMoving)
    {
      if (m_thisCamera.WorldToScreenPoint(m_player.transform.position).x >= Screen.width / 2)
      {
      
        Vector3 horizontal = new Vector3(1.0f, 0.0f, 0.0f);

        if (m_player.IsJumping)
        {
          transform.position += horizontal * Time.fixedDeltaTime * m_player.GetComponent<Rigidbody2D>().velocity.x;

        }
        else
        {
          transform.position += (horizontal * Time.fixedDeltaTime * m_player.WalkSpeed);
        }
      }
    }
    else
    {

      if (m_thisCamera.transform.position.x  < m_player.transform.position.x + m_playerOffset)
      {
        Vector3 horizontal = new Vector3(1.0f, 0.0f, 0.0f);
        if (m_player.IsJumping)
        {
          transform.position += horizontal * Time.fixedDeltaTime * m_camOffsetSpeed;

        }
        else
        {
          transform.position += (horizontal * Time.fixedDeltaTime * m_camOffsetSpeed);
        }
      }
    }
  }


  /// <summary>
  /// Reference to the camera to which this script is attached
  /// </summary>
  Camera m_thisCamera;

  /// <summary>
  /// A reference to the player's GO
  /// </summary>
  Player m_player;

  /// <summary>
  /// Variable so the camera is not completely centered on the player
  /// </summary>
  [SerializeField]
  float m_playerOffset;


  /// <summary>
  /// Variable to control how fast the camera moves when moving to offset
  /// </summary>
  [SerializeField]
  private float m_camOffsetSpeed;



}

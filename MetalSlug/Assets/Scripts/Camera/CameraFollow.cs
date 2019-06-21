using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  
  void LateUpdate()
  {
    if (m_thisCamera.WorldToScreenPoint(m_player.transform.position).x >= Screen.width / 2)
    {
      Debug.Log("Player reached the middle of screen. Moving away.");
      Vector3 horizontal = new Vector3(1.0f, 0.0f, 0.0f);

      if (m_player.IsJumping)
      {
        transform.position += horizontal * Time.fixedDeltaTime * m_player.GetComponent<Rigidbody2D>().velocity.x;

      }
      else
      {
        transform.position += (horizontal * Time.fixedDeltaTime * m_player.WalkSpeed) ;
      }
    }
    else if(m_stoppedMoving)
    {
      transform.position = new Vector3(m_player.transform.position.x + m_playerOffset, transform.position.y, transform.position.z);
    }
  }
  /// <summary>
  /// Variable so the camera is not completely centered on the player
  /// </summary>
  [SerializeField]
  float m_playerOffset;

  /// <summary>
  /// Reference to the camera to which this script is attached
  /// </summary>
  public Camera m_thisCamera;

  /// <summary>
  /// A reference to the player's GO
  /// </summary>
  public Player m_player;

  /// <summary>
  /// Value to check if plaer stopped moving
  /// </summary>
  [SerializeField]
  bool m_stoppedMoving;



}

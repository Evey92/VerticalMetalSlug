using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  void Start()
  {
    m_maxDistance = 5f;
    m_destination = transform.position;
    m_projection = m_player.transform.position;
  }

  // Update is called once per frame
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
        transform.position += horizontal * Time.fixedDeltaTime * m_player.WalkSpeed;
      }
    }
  }


  public Camera m_thisCamera;
  public Player m_player;
  private Vector2 m_destination;
  private Vector2 m_projection;
  public float m_maxDistance;
  public float m_speed = 4.9f;


}

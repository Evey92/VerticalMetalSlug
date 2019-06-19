using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      maxDistance = Screen.width / 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  float maxDistance;
  public Player m_player;
}

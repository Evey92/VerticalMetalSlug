using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Bomb
{
  // Start is called before the first frame update
  private void Awake()
  {
    m_maxDistance = 10;
    m_hSpeed = 10;

    m_totalTime = m_maxDistance / m_hSpeed;
  }

  public float m_totalTime;
}

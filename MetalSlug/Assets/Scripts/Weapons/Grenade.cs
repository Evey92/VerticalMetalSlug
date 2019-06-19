using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Bomb
{
  // Start is called before the first frame update
  private void Awake()
  {
    m_maxDistance = 8.0f;
    m_hSpeed = 4.0f;
    m_totalTime = m_maxDistance / m_hSpeed;
    m_expSource = m_explosion.GetComponent<AudioSource>();
    m_maxBounce = 1;
  }

  protected override void explode()
  {
    Instantiate(m_explosion, transform.position, transform.rotation);
    Destroy(gameObject);
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if(m_bounces >= m_maxBounce)
    {
      explode();
    }
    else
    {
      ++m_bounces;
    }
  }

  
  public float m_totalTime;
  public int m_maxBounce;
  public int m_bounces;
}

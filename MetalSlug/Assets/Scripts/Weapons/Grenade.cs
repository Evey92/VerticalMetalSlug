using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Bomb
{
  // Start is called before the first frame update
  private void Awake()
  {
    m_maxDistance = 5.0f;
    m_hSpeed = 5.5f;
    m_totalTime = m_maxDistance / m_hSpeed;
    m_expSource = m_explosion.GetComponent<AudioSource>();
    m_maxBounce = 1;
    m_player = GameObject.FindGameObjectWithTag("Player");
  }

  protected override void explode()
  {
    --m_player.GetComponent<Marco>().m_grenadesOnScreen;  
    Instantiate(m_explosion, transform.position, transform.rotation);
    Destroy(gameObject);
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if(!m_bounced)
    {
      m_bounced = true;
    }
    else
    {
      explode();
    }
  }

  
  public float m_totalTime;
  public int m_maxBounce;
  public bool m_bounced;
}

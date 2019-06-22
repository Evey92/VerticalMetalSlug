using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handgun : Weapon
{
  // Start is called before the first frame update
  private void Awake()
  {
    m_player = GameObject.FindGameObjectWithTag("Player");
  }

  public override void Shoot()
  {

    Bullet bulletInstance;
    if (m_player.GetComponent<Marco>().IsFacingRight)
    {
      bulletInstance = Instantiate(m_bullet, m_bulletSpawn.transform.position, new Quaternion(0, 0, m_bulletSpawn.transform.rotation.z, m_bulletSpawn.transform.rotation.w));
    }
    else
    {
      bulletInstance = Instantiate(m_bullet, m_bulletSpawn.transform.position, new Quaternion(0, 180, m_bulletSpawn.transform.rotation.z, m_bulletSpawn.transform.rotation.w));
    }
    bulletInstance.GetComponent<Rigidbody2D>().AddForce(m_bulletSpawn.transform.right * 500);

    m_audioSource.PlayOneShot(m_shotSound);
  }

  public AudioClip m_shotSound;
  public AudioSource m_audioSource;

}

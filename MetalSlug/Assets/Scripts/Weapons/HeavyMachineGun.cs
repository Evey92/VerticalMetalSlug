using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyMachineGun : Weapon
{
  private void Awake()
  {

    m_player = GameObject.FindGameObjectWithTag("Player");
  }

  public override void Shoot()
  {
    
    float shotRotation = 0;

    if(!m_player.GetComponent<Marco>().IsFacingRight)
    {
      shotRotation = 180;
    }
    
    StartCoroutine(instantiateBullets(shotRotation));
 
  }

  public IEnumerator instantiateBullets(float shotRotation)
  {
    for(int i = 0; i < m_bursts ; ++i)
    {
      Vector3 spaunpos = new Vector3(m_bulletSpawn.transform.position.x + Random.insideUnitCircle.x, m_bulletSpawn.transform.position.y + Random.insideUnitCircle.y * .45f, m_bulletSpawn.transform.position.z);
      Bullet bulletInstance;
      bulletInstance = Instantiate(m_bullet, spaunpos, new Quaternion(0, shotRotation, m_bulletSpawn.transform.rotation.z, m_bulletSpawn.transform.rotation.w));
      bulletInstance.GetComponent<Rigidbody2D>().AddForce(m_bulletSpawn.transform.right * 650);
      m_audioSource.PlayOneShot(m_shotSound);
      yield return new WaitForSeconds(m_delay);

    }
  }

  public void spawnBullet(Vector3 Position, Quaternion rotation)
  {
    Instantiate(m_bullet, Position, rotation);
  }

  
  
  public float m_delay = 1;
  public AudioClip m_shotSound;
  public AudioSource m_audioSource;



}

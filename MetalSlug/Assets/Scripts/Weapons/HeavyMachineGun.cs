using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyMachineGun : Weapon
{
  private void Awake()
  {
    m_ammo = 200;
    m_firePower = 1;
    m_fireRate = 0.02f;
    m_ammoSpent = 6;
    m_bursts = 2;
    m_instantiationTimer = m_cadence;
    m_player = GameObject.FindGameObjectWithTag("Player");
  }

  public override void Shoot()
  {
    float shotRotation = 0;

    if(!m_player.GetComponent<Marco>().IsFacingRight)
    {
      shotRotation = 180;
    }
    for (int i = 0; i < m_bursts; ++i)
    {
      m_instantiationTimer -= Time.deltaTime;

      if (m_instantiationTimer <= 0)
      {
        Bullet bulletInstance;
        bulletInstance = Instantiate(m_bullet, m_bulletSpawn.transform.position, new Quaternion(0, shotRotation, m_bulletSpawn.transform.rotation.z, m_bulletSpawn.transform.rotation.w));
        m_bullet.init(m_bulletSprite, m_firePower);
        bulletInstance.GetComponent<Rigidbody2D>().AddForce(m_player.transform.right * 650);

        m_instantiationTimer = m_cadence;
      }
      if (m_instantiationTimer <= 0)
      {
        Bullet bulletInstance2;
        bulletInstance2 = Instantiate(m_bullet, m_spawnPoint2.transform.position, new Quaternion(0, shotRotation, m_spawnPoint2.transform.rotation.z, m_bulletSpawn.transform.rotation.w));
        m_bullet.init(m_bulletSprite, m_firePower);
        bulletInstance2.GetComponent<Rigidbody2D>().AddForce(m_player.transform.right * 650);

        m_instantiationTimer = m_cadence;

      }

      if (m_instantiationTimer <= 0)
      {
        Bullet bulletInstance3;
        bulletInstance3 = Instantiate(m_bullet, m_spawnPoint3.transform.position, new Quaternion(0, shotRotation, m_spawnPoint3.transform.rotation.z, m_bulletSpawn.transform.rotation.w));
        m_bullet.init(m_bulletSprite, m_firePower);
        bulletInstance3.GetComponent<Rigidbody2D>().AddForce(m_player.transform.right * 650);

        m_instantiationTimer = m_cadence;

      }
    }
  }

  public void spawnBullet(Vector3 Position, Quaternion rotation)
  {
    Instantiate(m_bullet, Position, rotation);
  }

  [SerializeField]
  int m_bursts;
  float m_cadence = .2f;
  float m_instantiationTimer;

  public GameObject m_spawnPoint2;
  public GameObject m_spawnPoint3;
  


}

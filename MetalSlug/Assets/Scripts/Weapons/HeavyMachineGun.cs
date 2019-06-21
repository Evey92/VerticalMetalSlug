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
    m_ammoSpent = 18;
    m_bursts = 2;
  }

  public override void Shoot()
  {
    for (int i = 0; i < m_bursts; ++i)
    {
      Bullet bulletInstance;
      bulletInstance = Instantiate(m_bullet, m_bulletSpawn.transform.position, new Quaternion(0, m_player.transform.eulerAngles.y, m_bulletSpawn.transform.rotation.z, m_bulletSpawn.transform.rotation.w));
      m_bullet.init(m_bulletSprite, m_firePower);
      bulletInstance.GetComponent<Rigidbody2D>().AddForce(m_player.transform.right * 700);

      Bullet bulletInstance2;
      bulletInstance2 = Instantiate(m_bullet, m_spawnPoint2.transform.position, new Quaternion(0, m_player.transform.eulerAngles.y, m_spawnPoint2.transform.rotation.z, m_bulletSpawn.transform.rotation.w));
      m_bullet.init(m_bulletSprite, m_firePower);
      bulletInstance2.GetComponent<Rigidbody2D>().AddForce(m_player.transform.right * 650);

      Bullet bulletInstance3;
      bulletInstance3 = Instantiate(m_bullet, m_spawnPoint3.transform.position, new Quaternion(0, m_player.transform.eulerAngles.y, m_spawnPoint3.transform.rotation.z, m_bulletSpawn.transform.rotation.w));
      m_bullet.init(m_bulletSprite, m_firePower);
      bulletInstance3.GetComponent<Rigidbody2D>().AddForce(m_player.transform.right * 500);
    }
  }

  [SerializeField]
  int m_bursts;
  float m_cadence = 0;

  public GameObject m_spawnPoint2;
  public GameObject m_spawnPoint3;


}

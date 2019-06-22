using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handgun : Weapon
{
  // Start is called before the first frame update
  private void Awake()
  {
    m_ammo = 1;
    m_firePower = 1;
    m_fireRate = 0.01f;
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
    m_bullet.init(m_bulletSprite, m_firePower);
    bulletInstance.GetComponent<Rigidbody2D>().AddForce(m_bulletSpawn.transform.right * 700);
  }

}

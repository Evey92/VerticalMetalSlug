using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handgun : Weapon
{
  // Start is called before the first frame update

  private void Awake()
  {
    m_ammo = -1;
    m_firePower = 1;
    m_fireRate = 0.08f;
  }

  void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  public override void Shoot()
  {
    
    Bullet bulletInstance;
    bulletInstance = Instantiate(m_bullet, m_bulletSpawn.transform.position, new Quaternion(0, 0, m_bulletSpawn.transform.rotation.z, m_bulletSpawn.transform.rotation.w));
    m_bullet.init(m_bulletSprite, m_firePower);
    bulletInstance.GetComponent<Rigidbody2D>().AddForce(m_bulletSpawn.transform.right * 500);    
  }

  

  public Sprite m_bulletSprite;

}

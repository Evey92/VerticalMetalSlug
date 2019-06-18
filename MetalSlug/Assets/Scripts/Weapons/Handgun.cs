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
    m_fireRate = 0.2f;
  }

  void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  /// <summary>
  /// Used to shoot a bullet
  /// </summary>
  public override void Shoot()
  {
    Instantiate(m_bullet, m_bulletSpawn.transform);

  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyMachineGun : Weapon
{
  private void Awake()
  {
    m_ammo = 200;
    m_firePower = 2;
    m_fireRate = 0.08f;
  }

  // Update is called once per frame
  void Update()
    {
        
    }

  public override void Shoot()
  {
   
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
  /// <summary>
  /// Used to instantiate a m_bullet
  /// </summary>
  public abstract void Shoot();

  public float getFireRate()
  {
    return m_fireRate;
  }

  public GameObject m_bulletSpawn;
  public Bullet m_bullet;
  
  protected float m_firePower;
  protected float m_fireRate;
  protected float m_range;
  protected int m_ammo;

}

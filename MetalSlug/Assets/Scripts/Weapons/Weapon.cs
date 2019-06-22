using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
  /// <summary>
  /// Used to instantiate a m_bullet
  /// </summary>
  public abstract void Shoot();


  /// <summary>
  /// Used o get the fire rate 
  /// </summary>
  /// <returns></returns>
  public float getFireRate()
  {
    return m_fireRate;
  }

  
  
  /// <summary>
  /// Used to control how much damage it does
  /// </summary>
  [SerializeField]
  protected float m_firePower;

  /// <summary>
  /// Used to control how often you can fire
  /// </summary>
  [SerializeField]
  protected float m_fireRate;

  /// <summary>
  /// Used to control how often you can fire
  /// </summary>
  [SerializeField]
  protected float m_range;

  /// <summary>
  /// Used to keep track of how much ammo you've got left
  /// </summary>
  public int m_ammo;

  /// <summary>
  /// Used to keep track of how much ammo you've got left
  /// </summary>
  [SerializeField]
  public int m_bulletsShot = 0;

  /// <summary>
  /// Used to keep track of how much ammo you've got left
  /// </summary>
  public int m_ammoSpent;

  /// <summary>
  /// Used to keep track of how many bullets the wepon shoots
  /// </summary>
  [SerializeField]
  public int m_bursts = 2;

  /// <summary>
  /// Used to keep track of how many bullets the wepon shoots
  /// </summary>
  [SerializeField]
  public float m_weaponCooldown;
  /// <summary>
  /// Asset to assign the pweapons bullet sprite
  /// </summary>
  public Sprite m_bulletSprite;

  public WeaponItemKind.E m_weaponKind;

  public GameObject m_player;
  public GameObject m_bulletSpawn;
  public Bullet m_bullet;


}

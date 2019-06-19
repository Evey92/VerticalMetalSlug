using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : Entity
{
 
  public abstract void shootWeapon();
  public abstract void throwBomb();

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if(collision.gameObject.tag == "Floor" && !m_isGrounded)
    {
      m_isGrounded = true;
    }
  }

  /// <summary>
  /// Private mebers
  /// </summary>
  protected float m_lastShot;
  /// <summary>
  /// Public members
  /// </summary>
  public Weapon m_weapon;
  public SpriteRenderer m_characterSprite;
  public Sprite m_bombSprite;
  public GameObject m_weaponSlot;
  public bool m_canFire;
  public float m_speedMultiplier;
  public float m_horizontalSpeed;
  public float m_extraGravity;
  public int m_grnades;
  public int m_lives;
}

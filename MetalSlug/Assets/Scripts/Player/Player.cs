using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : Character
{
 
  public abstract void shootWeapon();
  public abstract void throwBomb();
  public abstract void jump();
  public abstract void walk();

  private void FixedUpdate()
  {
    //if (GetComponent<Rigidbody2D>().velocity.y > -1.0f && GetComponent<Rigidbody2D>().velocity.y <= 0)
    //{
    //  IsGrounded = true;
    //}
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.tag == "Floor" && !IsGrounded)
    {
      IsGrounded = true;
    }
  }

  /// <summary>
  /// Protected members
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
  public float m_jumpForce;
  public int m_grenades;
  public int m_lives;
}

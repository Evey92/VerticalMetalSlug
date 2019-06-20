using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : Character
{
 
  public abstract void shootWeapon();
  public abstract void throwBomb();
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
  /// Variable to control fire rate
  /// </summary>
  protected float m_lastShot;
  
  /// <summary>
  /// Reference to the weapon the player has equipped.
  /// </summary>
  public Weapon m_weapon;
  

  /// <summary>
  /// Reference to the spriteRenderer of the torso
  /// </summary>
  public SpriteRenderer m_characterSprite;

  /// <summary>
  /// Sprite for Marco's grenade 
  /// </summary>
  public Sprite m_bombSprite;

  /// <summary>
  /// Reference to the weapon slot for weapon changing
  /// </summary>
  public GameObject m_weaponSlot;

  /// <summary>
  /// Variable to check if Marco can fire. 
  /// Used to control fire rate 
  /// </summary>
  public bool m_canFire;

  /// <summary>
  /// Used to check if Marco is moving
  /// </summary>
  public bool m_isMoving;

  /// <summary>
  /// Multiplier to control the in air movement
  /// </summary>
  public float m_speedMultiplier;

  /// <summary>
  /// Variable used to check if Marco is moving left or right
  /// </summary>
  public float m_horizontalSpeed;

  /// <summary>
  /// Used to track how many grenades are in Marco's inventory
  /// </summary>
  public int m_grenadesLeft;

  /// <summary>
  /// Used to track how many lives are left
  /// </summary>
  public int m_lives;
}

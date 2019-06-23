using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemType
{
  public enum E
  {
    kGas,
    kBomb,
    kScore
  };
}


public abstract class Player : Character
{
 
  public abstract void shootWeapon();
  public abstract void throwBomb();
  public abstract void walk();
  public abstract void collectItem(int m_ammount, ItemType.E itemType);
  public abstract void collectWeapon(int m_ammount, WeaponItemKind.E itemType);

  private void FixedUpdate()
  {
    //if (GetComponent<Rigidbody2D>().velocity.y > -1.0f && GetComponent<Rigidbody2D>().velocity.y <= 0)
    //{
    //  IsGrounded = true;
    //}
  }

  //protected void OnCollisionEnter2D(Collision2D collision)
  //{
  //  if (collision.gameObject.layer == (1 << LayerMask.NameToLayer("Ground")) && !IsGrounded)
  //  {
  //    IsGrounded = true;
  //  }
  //}
  //
  //protected override void OnTriggerEnter2D(Collider2D other)
  //{
  //  base.OnTriggerEnter2D(other);
  //}

  protected override void OnCollisionEnter2D(Collision2D collision2D)
  {
    base.OnCollisionEnter2D(collision2D);

    

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
  /// Used to check if Marco is moving
  /// </summary>
  public bool m_isSlug;

  /// <summary>
  /// Used to check if Marco is moving
  /// </summary>
  public bool m_canKnife;

  /// <summary>
  /// Multiplier to control the in air movement
  /// </summary>
  public float m_speedMultiplier;

  /// <summary>
  /// Variable used to check if Marco is moving left or right
  /// </summary>
  public float m_horizontalSpeed;

  /// <summary>
  /// Value to control how long it takes for the gun to interpolate from front to up and down 
  /// </summary>
  [SerializeField]
  public float m_score= 0.0f;

  /// <summary>
  /// Value to control how long it takes for the gun to interpolate from front to up and down 
  /// </summary>
  [SerializeField]
  public float m_ammoLeft = 0.0f;

 

  /// <summary>
  /// Used to track how many grenades are in Marco's inventory
  /// </summary>
  public int m_grenadesLeft;

  /// <summary>
  /// Used to track how many grenades are in Marco's inventory
  /// </summary>
  public int m_maxGrenades = 99;

  /// <summary>
  /// Used to track how many grenades are in Marco's inventory
  /// </summary>
  public int m_defaultGrenades = 10;

  /// <summary>
  /// Used to track how many lives are left
  /// </summary>
  public int m_lives;

}

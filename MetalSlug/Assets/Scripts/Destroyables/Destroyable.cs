using UnityEditor;
using UnityEngine;

namespace DestroyableType
{
  public enum E
  {
    kCrate = 0,
    kExplosive,
    kBuilding,

    kNum
  };
}

namespace DropType
{
  public enum E
  {
    kWeapon = 0,
    kItem,

    kNum
  };
}

namespace WeaponDrop
{
  public enum E
  {
    kMachineGun = 0,
    kFlameShot,
    kRocketLauncher,
    kShotgun,

    kNum
  };
}

namespace ItemDrop
{
  public enum E
  {
    kSoupCan = 0,

    kNum
  };
}

public class Destroyable : MonoBehaviour
{
  #region Unity
  protected virtual void OnCollisionEnter2D(Collision2D collision2D)
  {
    if (collision2D.gameObject.layer == LayerMask.NameToLayer("PlayerBullet"))
    {
      ReceiveDamage(collision2D.gameObject);
    }
  }

  protected virtual void OnTriggerEnter2D(Collider2D collider2D)
  {
    if (collider2D.gameObject.layer == LayerMask.NameToLayer("PlayerBullet"))
    {
      ReceiveDamage(collider2D.gameObject);
    }
  }

  protected virtual void OnDestroy()
  {
    if (m_type == DestroyableType.E.kCrate)
    {
      switch (m_drop)
      {
        case DropType.E.kWeapon:
          switch (m_weapon)
          {
            case WeaponDrop.E.kMachineGun:
              Instantiate(Resources.Load("Prefabs/HeavyMachinePowerup"), transform.position, transform.rotation);
              break;
            case WeaponDrop.E.kFlameShot:

              break;
            case WeaponDrop.E.kRocketLauncher:

              break;
            case WeaponDrop.E.kShotgun:

              break;
          }
          break;
        case DropType.E.kItem:
          switch (m_item)
          {
            case ItemDrop.E.kSoupCan:

              break;
          }
          break;
      }
    }
    Destroy(gameObject);
  }
  #endregion

  #region Methods
  protected virtual void ReceiveDamage(GameObject gameObject)
  {
    switch (m_type)
    {
      case DestroyableType.E.kCrate:
        GetComponent<Animator>().SetBool("Destroyed", true);
        Destroy(this);
        break;
      case DestroyableType.E.kExplosive:
        // TODO: Take damage from source, like a bullet or a grenade
        Destroy(this);
        break;
      case DestroyableType.E.kBuilding:
        // TODO: If it's a helicopter destroy inmediatly, otherwise just take damage
        Destroy(this);
        break;
    }
  }
  #endregion

  #region Private Members
    
  #endregion

  #region Editor Members
  /// <summary>
  /// 
  /// </summary>
  [SerializeField]
  protected DestroyableType.E m_type;

  /// <summary>
  /// 
  /// </summary>
  protected DropType.E m_drop;

  /// <summary>
  /// 
  /// </summary>
  protected WeaponDrop.E m_weapon;

  /// <summary>
  /// 
  /// </summary>
  protected ItemDrop.E m_item;

  /// <summary>
  /// 
  /// </summary>
  protected int m_HP;
  #endregion

  #region Properties
  /// <summary>
  /// 
  /// </summary>
  public DestroyableType.E Type { get { return m_type; } }

  /// <summary>
  /// 
  /// </summary>
  public DropType.E Drop
  {
    set { m_drop = value; }
    get { return m_drop; }
  }

  /// <summary>
  /// 
  /// </summary>
  public WeaponDrop.E Weapon
  {
    set { m_weapon = value; }
    get { return m_weapon; }
  }

  /// <summary>
  /// 
  /// </summary>
  public ItemDrop.E Item
  {
    set { m_item = value; }
    get { return m_item; }
  }

  public int HP
  {
    set { m_HP = value; }
    get { return m_HP; }
  }
  #endregion
}

#region Custom Editor
[CustomEditor(typeof(Destroyable))]
public class DestroyableEditor : Editor
{
  int maxHP = 50;
  public override void OnInspectorGUI()
  {
    base.OnInspectorGUI();
    Destroyable destroyable = (Destroyable)target;

    if (destroyable.Type == DestroyableType.E.kCrate)
    {
      destroyable.Drop = (DropType.E)EditorGUILayout.EnumPopup("Drop Type: ", destroyable.Drop);
      if (destroyable.Drop == DropType.E.kWeapon)
      {
        destroyable.Weapon = (WeaponDrop.E)EditorGUILayout.EnumPopup("Weapon Drop: ", destroyable.Weapon);
      }
      if (destroyable.Drop == DropType.E.kItem)
      {
        destroyable.Item = (ItemDrop.E)EditorGUILayout.EnumPopup("Item Drop: ", destroyable.Item);
      }
    }
    if (destroyable.Type == DestroyableType.E.kBuilding || destroyable.Type == DestroyableType.E.kExplosive)
    {
      maxHP = EditorGUILayout.IntField("Max HP: ", maxHP);
      destroyable.HP = EditorGUILayout.IntSlider("HP: ", destroyable.HP, 1, maxHP);
    }
  }
}
#endregion

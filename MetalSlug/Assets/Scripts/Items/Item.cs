using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemKind
{
  public enum E
  {
    kWeapon = 0,
    kAmmo,
    kScore,
  }
}

public abstract class Item : Entity
{
  /// <summary>
  /// The variable that
  /// </summary>
  [SerializeField]
  public int m_ammount;
  public ItemKind.E m_itemKind;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponItemKind
{
  public enum E
  {
    kHangun = 0,
    kHeavyMachine,
    kFlameShot,
    kRocketLaunch,
  };
}

public class WeaponItem : Item
{

  public WeaponItemKind.E m_weponKind;
}

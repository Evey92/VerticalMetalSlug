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
  private void Start()
  {
    switch (m_weponKind)
    { 
      case WeaponItemKind.E.kHangun:
        m_ammount = 1;
        break;
      case WeaponItemKind.E.kHeavyMachine:
        m_ammount = 200;
        break;
      case WeaponItemKind.E.kFlameShot:
        m_ammount = 20;
        break;
      case WeaponItemKind.E.kRocketLaunch:
        m_ammount = 30;
        break;
      default:
        m_ammount = 0;
        break;
    }
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    
  }

  [SerializeField]
  AudioClip audioClip;

  public WeaponItemKind.E m_weponKind;
  public AudioSource m_audioSource;
  
}

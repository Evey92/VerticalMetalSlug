using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyMachineCrate : WeaponItem
{
  // Start is called before the first frame update
  void Start()
  {
    m_weponKind = WeaponItemKind.E.kHeavyMachine;
  }

  public int Collected()
  {
    
    return m_ammount;
  }


  protected void OnTriggerEnter2D(Collider2D collision)
  {
    
  }

}

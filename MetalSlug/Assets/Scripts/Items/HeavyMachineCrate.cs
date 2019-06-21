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


  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.tag == "Player")
    {
      Debug.Log("Collided with heavy");
      collision.GetComponent<Marco>().collectWeapon(m_ammount, m_weponKind);

    }
  }

}

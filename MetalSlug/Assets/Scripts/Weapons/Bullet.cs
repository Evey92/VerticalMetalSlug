using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
  public void init(Sprite bullet, float damage)
  {
    GetComponent<SpriteRenderer>().sprite = bullet;
    m_damage = damage;

    Vector2 newSize = GetComponent<SpriteRenderer>().sprite.bounds.size;
    GetComponent<CapsuleCollider2D>().size = newSize;
    //GetComponent<CapsuleCollider2D>() = new Vector2(newSize.x/2, newSize.y/2);
  }
    
    // Start is called before the first frame update
    void Start()
    {

      //Destroy(gameObject, 5.0f);

    }

  void OnBecameInvisible()
  {
    Destroy(gameObject);
  }

  // Update is called once per frame
  void Update()
    {
        
    }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    Destroy(gameObject);
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    Destroy(gameObject);
  }

  float m_damage;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetBomb : Bomb
{
  private void Awake()
  {
    sprite = GetComponent<Sprite>();
    Vector2 newSize = GetComponent<SpriteRenderer>().sprite.bounds.size;
    GetComponent<CapsuleCollider2D>().size = newSize;
  }

  protected override void explode()
  {
    ++m_player.GetComponent<Jet>().m_bombsonscreen;
    Destroy(gameObject);
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    explode();
  }
  public Sprite sprite;
}

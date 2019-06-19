using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bomb : MonoBehaviour
{

  protected abstract void explode();

  public GameObject m_explosion;
  public AudioSource m_expSource;
  public float m_damage;
  public float m_maxDistance;
  public float m_hSpeed;

}

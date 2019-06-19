using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Entity
{
#region Methods

#endregion

#region Gizmos

#endregion

#region Private Members

#endregion

#region Editor Members
  [SerializeField]
  protected float m_HP;
#endregion

#region Properties
  public float HP { get { return m_HP; } }
#endregion
}

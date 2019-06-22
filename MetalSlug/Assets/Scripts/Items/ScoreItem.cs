using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScoreItemKind
{
  public enum E
  {
    Fish = 0,
    Turkey,
    Pig,
    Letter,
    Medal,
  };
}

public class ScoreItem : Item
{
  // Start is called before the first frame update
  void Start()
  {

    switch (m_itemKind)
    {
      case ScoreItemKind.E.Fish:
        m_ammount = 500;
        break;
      case ScoreItemKind.E.Turkey:
        m_ammount = 1000;
        break;
      case ScoreItemKind.E.Pig:
        m_ammount = 1000;
        break;
      case ScoreItemKind.E.Letter:
        m_ammount = 500;
        break;
      case ScoreItemKind.E.Medal:
        m_ammount = 10;
        break;
      default:
        m_ammount = 0;
        break;
    }
  }

  //protected override void OnTriggerEnter2D(Collider2D other)
  //{
  //  throw new NotImplementedException();
  //}
  //
  //protected override void OnTriggerExit2D(Collider2D other)
  //{
  //  throw new NotImplementedException();
  //}

  protected override void InitStateMachine()
  {
    throw new NotImplementedException();
  }

  public  void Fall()
  {
    throw new NotImplementedException();
  }
  [SerializeField]
  ScoreItemKind.E m_itemKind;
}

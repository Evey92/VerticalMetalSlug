﻿using System;
using UnityEngine;

public class RebelDie : State<Rebel>
{
  public RebelDie(StateMachine<Rebel> stateMachine)
  : base(stateMachine) { }

  public override void OnStateEnter(Rebel rebel)
  {
    Debug.Log("Entered " + this.ToString() + " state.");

    rebel.Die();
  }

  public override void OnStatePreUpdate(Rebel rebel)
  {

  }

  public override void OnStateUpdate(Rebel rebel)
  {

  }

  public override void OnStateExit(Rebel rebel)
  {

  }
}

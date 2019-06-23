using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JetWaiting : State<Jet>
{

  public JetWaiting(StateMachine<Jet> stateMachine)
: base(stateMachine) { }

  public override void OnStateEnter(Jet jet)
  {
    Debug.Log("Jet Entered " + this.ToString() + " state.");
  }

  public override void OnStatePreUpdate(Jet jet)
  {

  }

  public override void OnStateUpdate(Jet jet)
  {

  }

  public override void OnStateExit(Jet jet)
  {

  }

}

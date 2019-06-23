using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JetFlying : State<Jet>
{
  public JetFlying(StateMachine<Jet> stateMachine)
: base(stateMachine) { }


  public override void OnStateEnter(Jet jet)
  {
    Debug.Log("Jet Entered " + this.ToString() + " state.");
    
  }

  public override void OnStatePreUpdate(Jet jet)
  {
    if(jet.HP <= 0)
    {
      m_StateMachine.ToState(jet.jetdie,jet);
    }
  }

  public override void OnStateUpdate(Jet jet)
  {
    if(jet.NearestPlayer != null)
    {
      if (jet.transform.position.x > jet.NearestPlayer.transform.position.x)
      {
        jet.transform.position = new Vector3(jet.transform.position.x - jet.WalkSpeed * Time.fixedDeltaTime,
          jet.transform.position.y, jet.transform.position.z);
      }
      else if (jet.transform.position.x < jet.NearestPlayer.transform.position.x)
      {
        jet.transform.position = new Vector3(jet.transform.position.x + jet.WalkSpeed * Time.fixedDeltaTime,
  jet.transform.position.y, jet.transform.position.z);
      }
      else if (jet.transform.position.x == jet.NearestPlayer.transform.position.x)
      {
        if (jet.Ammo > 0 && jet.m_bombsonscreen < 4)
        {
          jet.JETShoot();
        }
      }
    }
  }

  public override void OnStateExit(Jet jet)
  {

  }
}

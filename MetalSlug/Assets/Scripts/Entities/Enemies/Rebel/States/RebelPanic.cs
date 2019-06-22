using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebelPanic : State<Rebel>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  public RebelPanic(StateMachine<Rebel> stateMachine)
    : base(stateMachine) { }

  public override void OnStateEnter(Rebel rebel)
  {
    //Play Panic Animation
  }

  public override void OnStatePreUpdate(Rebel rebel)
  {
    m_StateMachine.ToState(rebel.rebelFlee, rebel);
  }

  public override void OnStateUpdate(Rebel rebel)
  {
  }

  public override void OnStateExit(Rebel rebel)
  {
  }
}

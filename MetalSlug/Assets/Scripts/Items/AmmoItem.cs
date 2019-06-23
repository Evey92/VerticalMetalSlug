using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmmoType
{
  public enum E
  {
    kBombCrate,
    kGasCan,
  };
}

public class AmmoItem : Item
{
  private void Awake()
  {
    InitStateMachine();
    m_audioSource = GameObject.FindGameObjectWithTag("SFXSource").GetComponent<AudioSource>();
  }

  private void Start()
  {
    switch (m_ammoKind)
    {
      case AmmoType.E.kBombCrate:
        m_ammount = 1;
        break;
      case AmmoType.E.kGasCan:
        m_ammount = 200;
        break;
      default:
        m_ammount = 0;
        break;
    }
  }

  private void FixedUpdate()
  {
    m_ammoStateMachine.OnState(this);
  }

  //protected override void OnTriggerEnter2D(Collider2D collision)
  //{
  //  base.OnTriggerEnter2D(collision);
  //
  //}
  //
  //protected override void OnTriggerExit2D(Collider2D other)
  //{
  //
  //}

  protected override void InitStateMachine()
  {
    m_ammoStateMachine = new StateMachine<AmmoItem>();
    ammoIdleState = new AmmoItemIdle(m_ammoStateMachine);
    ammoFallState = new AmmoFallState(m_ammoStateMachine);
    ammoPickedUpstate = new AmmoPickedUpState(m_ammoStateMachine);
    ammoDestroyedstate = new AmmoDestroyed(m_ammoStateMachine);

    m_ammoStateMachine.Init(ammoIdleState, this);
  }

  public void Destroy()
  {
    Destroy(gameObject);
  }

  /// <summary>
  /// The state machine that handles all the states for the player
  /// </summary>
  private StateMachine<AmmoItem> m_ammoStateMachine;

  [SerializeField]
  public AudioClip m_pickUpClip;

  public AmmoItemIdle ammoIdleState;
  public AmmoFallState ammoFallState;
  public AmmoPickedUpState ammoPickedUpstate;
  public AmmoDestroyed ammoDestroyedstate;

  public AmmoType.E m_ammoKind;
  public AudioSource m_audioSource;
}

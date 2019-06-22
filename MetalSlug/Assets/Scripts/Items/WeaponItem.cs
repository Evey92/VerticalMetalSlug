using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponItemKind
{
  public enum E
  {
    kHangun = 0,
    kHeavyMachine,
    kFlameShot,
    kRocketLaunch,
  };
}

public class WeaponItem : Item
{

  private void Awake()
  {
    InitStateMachine();
    m_audioSource = GameObject.FindGameObjectWithTag("SFXSource").GetComponent<AudioSource>();
  }

  private void Start()
  {
    switch (m_weponKind)
    { 
      case WeaponItemKind.E.kHangun:
        m_ammount = 1;
        break;
      case WeaponItemKind.E.kHeavyMachine:
        m_ammount = 200;
        break;
      case WeaponItemKind.E.kFlameShot:
        m_ammount = 30;
        break;
      case WeaponItemKind.E.kRocketLaunch:
        m_ammount = 20;
        break;
      default:
        m_ammount = 0;
        break;
    }
  }

  private void FixedUpdate()
  {
    m_weaponStateMachine.OnState(this); 
  }

  protected override void OnTriggerEnter2D(Collider2D collision)
  {
    base.OnTriggerEnter2D(collision);

  }

  protected override void OnTriggerExit2D(Collider2D other)
  {

  }

  protected override void InitStateMachine()
  {
    m_weaponStateMachine = new StateMachine<WeaponItem>();
    weaponIdleState = new WeaponItemIdle(m_weaponStateMachine);
    weaponFallState = new WeaponItemFall(m_weaponStateMachine);
    weaponPickedUpstate = new WeaponItemPickedUp(m_weaponStateMachine);
    weaponDestroyedstate = new WeaponItemDestroyed(m_weaponStateMachine);

    m_weaponStateMachine.Init(weaponIdleState, this);
  }

  public void Destroy()
  {
    Destroy(gameObject);
  }

  /// <summary>
  /// The state machine that handles all the states for the player
  /// </summary>
  private StateMachine<WeaponItem> m_weaponStateMachine;

  [SerializeField]
  public AudioClip m_pickUpClip;

  public WeaponItemIdle weaponIdleState;
  public WeaponItemFall weaponFallState;
  public WeaponItemPickedUp weaponPickedUpstate;
  public WeaponItemDestroyed weaponDestroyedstate;

  public WeaponItemKind.E m_weponKind;
  public AudioSource m_audioSource;
  
}

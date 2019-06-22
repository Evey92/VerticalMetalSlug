using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Marco>();   
  }

  // Update is called once per frame
  void Update()
  {
        
  }

  public void updateUI()
  {
    m_ARMS.text = m_player.m_ammoLeft.ToString();
    m_BOMB.text = m_player.m_grenadesLeft.ToString();
    m_LIVES.text = m_player.m_lives.ToString();
    m_SCORE.text = m_player.m_score.ToString();
  }

  /// <summary>
  /// Reference to the player.
  /// </summary>
  Player m_player;

  /// <summary>
  /// All the UI Text objects
  /// </summary>
  public Text m_ARMS;
  public Text m_BOMB;
  public Text m_LIVES;
  public Text m_TIMER;
  public Text m_SCORE;
  

}

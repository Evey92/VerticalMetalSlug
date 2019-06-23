using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
  
  public void initUI(int bulletsLeft, int bombsLeft, int livesLeft, int newScore)
  {
    m_ARMS.text = bulletsLeft.ToString();
    m_BOMB.text = bombsLeft.ToString();
    m_LIVES.text = livesLeft.ToString();
    m_SCORE.text = newScore.ToString();
  }

  public void setARMS(int bulletsLeft)
  {
    m_ARMS.text = bulletsLeft.ToString();
  }

  public void setBombs(int bombsLeft)
  {
    m_BOMB.text = bombsLeft.ToString();
  }

  public void setLives(int livesLeft)
  {
    m_LIVES.text = livesLeft.ToString();
  }

  public void addScore(int newScore, Player player)
  {
    player.m_score += newScore;
    m_SCORE.text = player.m_score.ToString();
  }

  /// <summary>
  /// All the UI Text objects
  /// </summary>
  public Text m_ARMS;
  public Text m_BOMB;
  public Text m_LIVES;
  public Text m_SCORE;
  

}

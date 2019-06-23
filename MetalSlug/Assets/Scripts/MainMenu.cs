using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    
    
   
  // Start is called before the first frame update
  void Start() {
      VideoP.playOnAwake = true;
      VideoP.isLooping = true;
      VideoP.clip = videoClip_Main; 
      VideoP.Play();
  }

  // Update is called once per frame
  void Update() {

    if(Input.GetKey(KeyCode.Alpha5) && next == false){
      VideoP.playOnAwake = true;
      VideoP.isLooping = false;
      VideoP.clip = videoClip_Load;
      next = true;
      m_audioSource.Stop();

      m_audioSource.PlayOneShot(m_coinClip);
    }

    if((Input.GetKey(KeyCode.Alpha1) || VideoP.isPaused)&& next==true){
        VideoP.clip = videoClip_Tutorial;
        VideoP.Play();
        startGame = true;
      m_audioSource.clip = m_OperationsSound;
      m_audioSource.Play();
    }

    if((Input.GetKeyDown(KeyCode.X) || VideoP.isPaused)  && startGame == true){
        SceneManager.LoadScene("NIVEL 1");
    }

}

  public UnityEngine.Video.VideoClip videoClip_Main;
  public UnityEngine.Video.VideoClip videoClip_Load;
  public UnityEngine.Video.VideoClip videoClip_Tutorial;
  public UnityEngine.Video.VideoPlayer VideoP;
  
  [SerializeField]
  private AudioSource m_audioSource;

  [SerializeField]
  private AudioClip m_coinClip;

  [SerializeField]
  private AudioClip m_OperationsSound;

    private bool next = false;
  private bool startGame = false;

}

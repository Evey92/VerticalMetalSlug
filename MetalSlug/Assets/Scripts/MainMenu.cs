using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public UnityEngine.Video.VideoClip videoClip_Main;
    public UnityEngine.Video.VideoClip videoClip_Load;
    public UnityEngine.Video.VideoClip videoClip_Tutorial;
    public UnityEngine.Video.VideoPlayer VideoP;
    private bool next = false;
    private bool startGame = false;
    
    
   
    // Start is called before the first frame update
    void Start() {
        VideoP.playOnAwake = true;
        VideoP.isLooping = true;
        VideoP.clip = videoClip_Main; 
        VideoP.Play();
    }

    // Update is called once per frame
    void Update() {

        if(Input.GetKey(KeyCode.P) && next == false){
            VideoP.playOnAwake = true;
            VideoP.isLooping = false;
            VideoP.clip = videoClip_Load;
            next = true;
        }

        if((Input.GetKey(KeyCode.Q) || VideoP.isPaused)&& next==true){
            VideoP.clip = videoClip_Tutorial;
            VideoP.Play();
            startGame = true;
        }

        if((Input.GetKeyDown(KeyCode.X) || VideoP.isPaused)  && startGame == true){
            SceneManager.LoadScene("NIVEL 1");
       }

    }
}

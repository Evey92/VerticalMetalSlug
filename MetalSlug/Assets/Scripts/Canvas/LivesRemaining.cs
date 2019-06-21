using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LivesRemaining : MonoBehaviour {
    
    public Text livesRem;

    int nLives = 0;

    const int livesStart = 2;
    
    
    // Start is called before the first frame update
    void Start() {
        nLives = livesStart;
    }

    void died(){
        Debug.Log("Jugador murio");
        nLives-=1;
    }

    // Update is called once per frame
    void Update() {
        livesRem.text = nLives.ToString();
    }

}

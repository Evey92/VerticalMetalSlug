using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BOMB : MonoBehaviour {

    public Text bombas;

    const int newBombs = 10;

    int nBombs = 0;
    
    //Funcion para pasar los datos de bombas
    void actualBomb(int bomb) {
        nBombs = bomb;
    } 

    // Start is called before the first frame update
    void Start() {
        nBombs=newBombs;
    }

    // Update is called once per frame
    void Update() {
        bombas.text = nBombs.ToString();
    }
}

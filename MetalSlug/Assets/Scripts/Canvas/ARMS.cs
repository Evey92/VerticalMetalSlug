using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARMS : MonoBehaviour {

    public Text muni;

    int nMunicion = 0;


    //Funcion para pasar los datos restantes de bombas
    void actualARMS(int ammo){
        nMunicion = ammo;
    }


    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        muni.text = nMunicion.ToString();
    }
}

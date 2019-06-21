using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Points : MonoBehaviour {

    //Para disparos
    const int shootPoints = 100;

    //Para el golpe
    const int meleePoints = 300;

    //Para las medallas, carta y pez    "Extras 1"
    const int x = 500; 

    //Para el Cerdo, pollo y gasolina   "Extras 2"
    const int y = 1000;

    //Para el oso de peluche
    const int  peluchePoints = 5000;

    public Text points;

    int nPuntos = 0;



//Incrementa puntos por disparo
    void shootAtack(){
        Debug.Log("Se ha disparado");
        nPuntos+=shootPoints;
    }


//Incrementar puntos por melee
    void meleeAtack(){
        Debug.Log("Se ha golpeado");
        nPuntos+=meleePoints;
    }

//Incrementa puntos por oso de peluche
    void extraPoints(){
        Debug.Log("Has recogido un oso de peluche");
        nPuntos += peluchePoints;
    }

//Incrementa puntos por Extras 1
    void extras1Points(){
        nPuntos+=x;
    }

//Incrementa puntos por Extras 2
    void extras2Points(){
        nPuntos+=y;
    }



    // Update is called once per frame
    void Update() {
        //Evaluar si la bala pegó al objetivo
        points.text = nPuntos.ToString();
    }

}

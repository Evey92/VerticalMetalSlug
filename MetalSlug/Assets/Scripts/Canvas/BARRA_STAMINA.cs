using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BARRA_STAMINA : MonoBehaviour
{
    Slider BarraVida;
    public float max;
    public float act;
    int cont = 0;

    void Awake() {
        BarraVida = GetComponent<Slider>();    
    }
    

    void Start() {
        getVida();
    }

    
    void Update() {
        //ActualizarValorBarra(max, act);
    }

    public void ActualizarValorBarra(float valorMax, float valorAct) {
        float porcentaje;
        porcentaje = valorAct / valorMax;
        BarraVida.value = porcentaje;
    }

    void getVida() {
        if (cont <= 0) {
            ActualizarValorBarra(10, cont);
            cont++;
        }
        else {
            cont = 0;
        }
        Invoke("getVida", 1f);
    }

}

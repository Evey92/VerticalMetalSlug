using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TIMER : MonoBehaviour
{
    public Text tiempo;//objeto tipo texto del canvas que mostrara el tiempo restante en pantalla
    public int TiempoLimite;//cuanto dura la partida
    float nTiempo = 0;

    // Start is called before the first frame update
    void Start() {
        nTiempo = TiempoLimite*5;
    }

    // Update is called once per frame
    void Update() {
        if (TiempoLimite == 0) {//si se acaba el tiempo
        
            Debug.Log("Fin");
            tiempo.text = "00";
            //detener partida, ver quien es ganador ,volver al menu etc...
            Application.Quit();
        }
        else {
            nTiempo -= Time.deltaTime;
            TiempoLimite = (int)nTiempo;
            tiempo.text = (TiempoLimite/5).ToString();
        }

    }
}
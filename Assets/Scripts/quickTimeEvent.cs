using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class quickTimeEvent : MonoBehaviour
{
    //public TMP_Text textTime;
    //public TMP_Text textTecla;

    public KeyCode teclaCorrecta;

    [SerializeReference]float time = 0;

    public float startTime = 0;

    bool puedePresionar = true;

    public GameObject prueba;
    public GameObject pruebaError;

    bool teclaCorrectaPresionada(){
        return Input.GetKeyDown(teclaCorrecta);
    }

    void Start(){
        //textTecla.text = teclaCorrecta.ToString();
        time = startTime;
    }

    void Update(){
        if (puedePresionar && time > 0){
            time -= Time.deltaTime;
            //textTime.text = ((int)startTime).ToString();
            comprobarQTE();
        }
        else
        {
            error();
        }
    }

    void comprobarQTE(){
        if(Input.anyKeyDown && !tocoTeclaMouse()){
            if (teclaCorrectaPresionada())
            {
                success();
            }
            else
            {
                puedePresionar = false;
            }
            
        }
    }

    void success(){
        puedePresionar = false;
        Instantiate(prueba);
    }

    void error(){
        puedePresionar = false;
        Instantiate(pruebaError);
    }

    bool tocoTeclaMouse(){
        return Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.Mouse2)
        || Input.GetKeyDown(KeyCode.Mouse3) || Input.GetKeyDown(KeyCode.Mouse4) || Input.GetKeyDown(KeyCode.Mouse5) ||
        Input.GetKeyDown(KeyCode.Mouse6);
    }
}

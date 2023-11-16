using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject menuOpciones;

    Move gato;

    playSleepMusic sleepMusic;

    // Start is called before the first frame update
    void Start()
    {
        gato = GameObject.Find("Character").GetComponent<Move>();

        if (GameObject.Find("InteractableRadio"))
        {
            sleepMusic = GameObject.Find("InteractableRadio").GetComponent<playSleepMusic>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        abrirMenuOpciones();
    }

    void abrirMenuOpciones()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && menuOpciones.activeSelf == false && gato.getMove())
        {
            pausarRadio();
            menuOpciones.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void unpause()
    {
        despausarRadio();
        menuOpciones.SetActive(false);
        Time.timeScale = 1;
    }

    bool hayRadioEnNivel()
    {
        return sleepMusic != null;
    }

    void pausarRadio()
    {
        if (hayRadioEnNivel())
        {
            sleepMusic.pauseMusic();
        }
    }

    void despausarRadio()
    {
        if (hayRadioEnNivel())
        {
            sleepMusic.playMusic();
        }       
    }
}

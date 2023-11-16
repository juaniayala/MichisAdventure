using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSleepMusic : Interactable
{
    [SerializeField]private PerroAI perro;

    private AudioSource cancion;
    public AudioSource musicaFondo;
    // Start is called before the first frame update
    void Start()
    {
        perro = GameObject.Find("Perro").GetComponent<PerroAI>();
        cancion = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void interact()
    {       
        playMusic();
        Debug.Log("Interactuando");
        perro.GoToSleep();
    }

    public void pauseMusic()
    {
        musicaFondo.Play();
        cancion.Pause();
        canInteract = true;
    }

    public void playMusic()
    {
        musicaFondo.Pause();
        cancion.Play();
        canInteract = false;
    }
}

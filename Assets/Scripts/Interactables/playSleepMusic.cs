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

    public void pauseMusicDuringPause()
    {
        if (canInteract == false)
        {
            Debug.Log("Pausando..." + canInteract + ".");
            cancion.Pause();
            musicaFondo.Play();
        }
    }

    public void playMusic()
    {
        musicaFondo.Pause();
        cancion.Play();
        canInteract = false;
    }

    public void unpauseMusicAfterPause()
    {
        if (canInteract == false)
        {
            Debug.Log("Despausando..." + canInteract + ".");
            musicaFondo.Pause();
            cancion.Play();
        }
    }
}

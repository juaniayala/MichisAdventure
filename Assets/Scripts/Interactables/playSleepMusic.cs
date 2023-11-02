using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSleepMusic : Interactable
{
    [SerializeField]private PerroAI perro;

    private AudioSource cancion;
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
        canInteract = false;
        cancion.Play();
        Debug.Log("Interactuando");
        perro.GoToSleep();
    }

    public void pauseMusic()
    {
        cancion.Pause();
        canInteract = true;
    }
}

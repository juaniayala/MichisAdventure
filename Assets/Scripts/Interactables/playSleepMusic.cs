using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSleepMusic : Interactable
{
    [SerializeField]private PerroAI perro;
    // Start is called before the first frame update
    void Start()
    {
        perro = GameObject.Find("Perro").GetComponent<PerroAI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void interact()
    {
        Debug.Log("Interactuando");
        perro.GoToSleep();
    }
}

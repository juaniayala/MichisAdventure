using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class escapeWindow : Interactable
{
    public levelManager lManager;

    public string nivel;

    public override void interact()
    {
        if (lManager.canEscape())
        {
            canInteract = false;
            SceneManager.LoadScene("Victoria" + nivel);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] protected bool canInteract = true;
    public abstract void interact();

    public bool getCanInteract()
    {
        return canInteract;
    } 
}

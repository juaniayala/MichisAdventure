using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField]bool canInteract = false;

    GameObject collisionInteract = null;
    // Start is called before the first frame update
    void Start()
    {
        canInteract = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (collisionInteract == null)
        {
            canInteract = false;
        }
        
        if (canInteract && collisionInteract.GetComponent<Interactable>().getCanInteract())
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                collisionInteract.GetComponent<Interactable>().interact();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collisionTemp)
    {
        if (collisionTemp.gameObject.CompareTag("Interactable"))
        {
            collisionInteract = collisionTemp.gameObject;
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collisionTemp)
    {
        if (collisionTemp.gameObject.CompareTag("Interactable"))
        {
            canInteract = false;
            collisionInteract = null;
        }       
    }
}

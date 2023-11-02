using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seeKey : MonoBehaviour
{
    public GameObject tecla;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.gameObject.CompareTag("Player"))
        {
            tecla.SetActive(true);
        }      
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.gameObject.CompareTag("Player"))
        {
            tecla.SetActive(false);
        }
    }
}

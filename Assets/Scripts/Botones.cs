using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void jugar()
    {
        SceneManager.LoadScene("MovimientoGato");
    }

    public void tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void salir()
    {
        Application.Quit();
    }
}

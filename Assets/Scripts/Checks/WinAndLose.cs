using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinAndLose : MonoBehaviour
{
    [SerializeField]int comidaAgarrada = 0;

    public Timer timer;

    PerroAI perro;

    public string nivel;

    private void Start()
    {
        comidaAgarrada = 0;
        perro = GameObject.Find("Perro").GetComponent<PerroAI>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Comida"))
        {
            collision.gameObject.SetActive(false);
            comidaAgarrada++;            
        }
        else if (collision.gameObject.CompareTag("Perro"))
        {
            if (!perro.getSleeping())
            {
                perder();
            }
            
        }
    }

    private void Update()
    {
        if (timer.getFinished())
        {
            perder();
        }
    }

    public void perder()
    {
        SceneManager.LoadScene("Derrota" + nivel);
    }

    public int getFood()
    {
        return comidaAgarrada;
    }
}

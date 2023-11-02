using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinAndLose : MonoBehaviour
{
    [SerializeField]int comidaAgarrada = 0;

    private void Start()
    {
        comidaAgarrada = 0;
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
            SceneManager.LoadScene("Derrota");
        }
    }

    public int getFood()
    {
        return comidaAgarrada;
    }
}

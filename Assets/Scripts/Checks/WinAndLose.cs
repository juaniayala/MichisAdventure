using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinAndLose : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Comida"))
        {
            SceneManager.LoadScene("Victoria");
        }
        else if (collision.gameObject.CompareTag("Perro"))
        {
            SceneManager.LoadScene("Derrota");
        }
    }
}

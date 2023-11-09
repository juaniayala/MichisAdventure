using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class levelManager : MonoBehaviour
{
    public WinAndLose wlCheck;

    public TMP_Text counterText;

    public TMP_Text searchText, escapeText;

    public GameObject menuOpciones;

    int foodCounter = 0;

    public int foodTotal;

    Move gato;
    // Start is called before the first frame update
    void Start()
    {
        foodCounter = 0;

        gato = GameObject.Find("Character").GetComponent<Move>();

        searchText.gameObject.SetActive(true);
        escapeText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        foodCounter = wlCheck.getFood();
        counterText.text = foodCounter.ToString();

        if (canEscape())
        {
            searchText.gameObject.SetActive(false);
            escapeText.gameObject.SetActive(true);
        }

        abrirMenuOpciones();
    }

    public bool canEscape()
    {
        return foodCounter == foodTotal;
    }

    void abrirMenuOpciones()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && menuOpciones.activeSelf == false && gato.getMove())
        {
            menuOpciones.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void unpause()
    {
        menuOpciones.SetActive(false);
        Time.timeScale = 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class levelManager : MonoBehaviour
{
    public WinAndLose wlCheck;

    public TMP_Text counterText;

    public TMP_Text searchText, escapeText;


    int foodCounter = 0;

    public int foodTotal;

    
    // Start is called before the first frame update
    void Start()
    {
        foodCounter = 0;      

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
    }

    public bool canEscape()
    {
        return foodCounter == foodTotal;
    }

    
}

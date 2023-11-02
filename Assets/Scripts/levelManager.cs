using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class levelManager : MonoBehaviour
{
    public WinAndLose wlCheck;

    public TMP_Text counterText;

    int foodCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        foodCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        foodCounter = wlCheck.getFood();
        counterText.text = foodCounter.ToString();
    }

    public bool canEscape()
    {
        return foodCounter > 0;
    }
}

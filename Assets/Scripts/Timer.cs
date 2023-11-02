using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float startTimeValue = 90;
    [SerializeField] float timeValue;
    private TMP_Text timeText;
    [SerializeField] private bool finishedCountdown;

    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<TMP_Text>();
        timeValue = startTimeValue;
        finishedCountdown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!finishedCountdown)
        {
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
            }
            else
            {
                terminarCuenta();
            }

            DisplayTime(timeValue);
        }
    }

    void terminarCuenta()
    {
        finishedCountdown = true;
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public bool getFinished()
    {
        return finishedCountdown;
    }

}

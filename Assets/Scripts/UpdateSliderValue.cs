using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UpdateSliderValue : MonoBehaviour
{
    private Slider thisSlider;

    public AudioMixer audioMixer;

    public string exposedParameterName;
    // Start is called before the first frame update
    void Start()
    {
        thisSlider = GetComponent<Slider>();
        updateValue(exposedParameterName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updateValue(string parameter)
    {
        float result = 0f;
        audioMixer.GetFloat(parameter, out result);
        thisSlider.value = result;
    }
}

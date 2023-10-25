using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class menuVideo : MonoBehaviour
{
    public Dropdown dropdownRes;
    public Dropdown dropdownCalidad;
    public Dropdown dropdownFps;
    void Start()
    {
        // Limpia la lista de calidades y luego agrega las que son
        dropdownCalidad.ClearOptions();
        dropdownCalidad.AddOptions(QualitySettings.names.ToList());

        // Obtiene el valor actual de la lista de calidades gráficas
        dropdownCalidad.value = QualitySettings.GetQualityLevel();

        // Obtener las resoluciones soportadas por la pantalla y ordenarlas
        Resolution[] resolutions = Screen.resolutions.OrderBy(res => res.width).ToArray();

        // Agregar las resoluciones al dropdown
        foreach (Resolution resolution in resolutions)
        {
            // Comprobar si la resolución comienza por 1000
            if (resolution.width.ToString().StartsWith("1000"))
            {
                agregarSiNoEsta(dropdownRes.options, resolution);
            }
            else
            {
                InsertarSiNoEsta(dropdownRes.options, resolution);
            }
        }

        // Actualizar el valor seleccionado del dropdown con la resolución actual
        Resolution currentResolution = Screen.currentResolution;
        string currentOption = currentResolution.width + "x" + currentResolution.height;
        dropdownRes.value = dropdownRes.options.FindIndex(option => option.text == currentOption);
        dropdownFps.value = currentResolution.refreshRate;

        // Agregar listeners para cambiar los valores de los dropdowns
        dropdownRes.onValueChanged.AddListener(OnDropdownResValueChanged);
        dropdownCalidad.onValueChanged.AddListener(OnDropdownCalidadValueChanged);
        dropdownFps.onValueChanged.AddListener(OnFPSSelection);

        // Cargar preferencias de configuraciones
        dropdownRes.value = PlayerPrefs.GetInt("resPref", dropdownRes.options.FindIndex(option => option.text == currentOption));
        dropdownFps.value = PlayerPrefs.GetInt("fpsPref", currentResolution.refreshRate);
        dropdownCalidad.value = PlayerPrefs.GetInt("calidadPref", QualitySettings.GetQualityLevel());
    }

    void agregarSiNoEsta(List<Dropdown.OptionData> lista, Resolution res)
    {
        Dropdown.OptionData opcion = new Dropdown.OptionData(res.width + "x" + res.height);
        if (!lista.Contains(opcion))
        {
            lista.Add(opcion);
        }
    }

    void InsertarSiNoEsta(List<Dropdown.OptionData> lista, Resolution res)
    {
        Dropdown.OptionData opcion = new Dropdown.OptionData(res.width + "x" + res.height);
        if (!lista.Contains(opcion))
        {
            lista.Insert(0, opcion);
        }
    }

    void OnDropdownResValueChanged(int index)
    {
        string selectedOption = dropdownRes.options[index].text;
        string[] dimensions = selectedOption.Split('x');
        int width = int.Parse(dimensions[0]);
        int height = int.Parse(dimensions[1]);

        // Cambiar la resolución de la pantalla
        Screen.SetResolution(width, height, Screen.fullScreen, 0);

        //Guardar la opcion
        PlayerPrefs.SetInt("resPref", index);
    }

    void OnDropdownCalidadValueChanged(int value)
    {
        QualitySettings.SetQualityLevel(value);

        //Guardar la opcion
        PlayerPrefs.SetInt("calidadPref", value);
    }

    void OnFPSSelection(int index)
    {
        // Obtener el valor seleccionado del Dropdown
        string selectedOption = dropdownFps.options[index].text;

        // Convertir el valor seleccionado a entero
        int targetFPS = int.Parse(selectedOption);

        // Establecer el objetivo de FPS
        Application.targetFrameRate = targetFPS;

        //Guardar la opcion
        PlayerPrefs.SetInt("fpsPref", targetFPS);
    }
}
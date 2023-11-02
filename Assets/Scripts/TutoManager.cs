using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutoManager : MonoBehaviour
{
    [SerializeField]int checkpointsCleared;

    public GameObject[] checkpoints = new GameObject[4];

    public GameObject panelVictoria;

    private Move character;

    private Animation charAnim;

    public TMP_Text contadorCheckpoints;
    // Start is called before the first frame update
    void Start()
    {       
        character = GameObject.Find("Character").GetComponent<Move>();
        charAnim = GameObject.Find("Character").GetComponent<Animation>();
        panelVictoria.SetActive(false);
        checkpointsCleared = 0;
        actualizarContador();
    }

    public void clearCheckpoint()
    {
        checkpointsCleared++;
        actualizarContador();
        activateCheckpoint(checkpointsCleared);
    }

    void activateCheckpoint(int num)
    {
        checkpoints[num - 1].SetActive(false);
        if (checkpointsCleared < checkpoints.Length)
        {
            checkpoints[num].SetActive(true);
        }
        else
        {          
            panelVictoria.SetActive(true);
            character.stopMoving();
            charAnim.winAnim();
        }
    }
    
    void actualizarContador()
    {
        contadorCheckpoints.text = checkpointsCleared.ToString();
    }
}

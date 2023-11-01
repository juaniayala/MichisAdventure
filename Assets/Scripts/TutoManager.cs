using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoManager : MonoBehaviour
{
    [SerializeField]int checkpointsCleared;

    public GameObject[] checkpoints = new GameObject[4];

    public GameObject panelVictoria;

    private Move character;
    // Start is called before the first frame update
    void Start()
    {
        panelVictoria.SetActive(false);
        checkpointsCleared = 0;
        character = GameObject.Find("Character").GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clearCheckpoint()
    {
        checkpointsCleared++;
        activateCheckpoint(checkpointsCleared);
    }

    void activateCheckpoint(int num)
    {
        if (checkpointsCleared < checkpoints.Length)
        {
            checkpoints[num - 1].SetActive(false);
            checkpoints[num].SetActive(true);
        }
        else
        {
            panelVictoria.SetActive(true);
            character.stopMoving();
        }
    }
}

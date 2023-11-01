using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private TutoManager tManager;
    // Start is called before the first frame update
    void Start()
    {
        tManager = GameObject.Find("TutoManager").GetComponent<TutoManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tManager.clearCheckpoint();
        }
    }
}

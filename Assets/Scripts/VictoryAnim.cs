using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryAnim : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim.SetTrigger("Win");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

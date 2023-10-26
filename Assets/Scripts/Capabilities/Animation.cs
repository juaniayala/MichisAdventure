using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Ground ground;
    private Move move;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<Move>();
        ground = GetComponent<Ground>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Velocity", move.velocity.x);
        anim.SetBool("Grounded", ground.onGround);
    }
}

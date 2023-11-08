using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatform : MonoBehaviour
{
    PlatformEffector2D platformEffector2;
    [SerializeReference]bool puedeRotar = false;

    private Move chMove;
    // Start is called before the first frame update
    void Start()
    {
        platformEffector2 = GetComponent<PlatformEffector2D>();
        chMove = GameObject.Find("Character").GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if (puedeRotar)
        {
            if (Input.GetKeyDown(KeyCode.S) && chMove.getMove())
            {
                platformEffector2.rotationalOffset = 180;
            }
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        reiniciarRotacion();
    }

    public void activarRotacion()
    {
        platformEffector2.rotationalOffset = 0;
        puedeRotar = true;
    }

    void reiniciarRotacion()
    {
        puedeRotar = false;
    }
}

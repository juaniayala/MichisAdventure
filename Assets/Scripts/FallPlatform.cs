using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatform : MonoBehaviour
{
    PlatformEffector2D platformEffector2;
    [SerializeField]bool puedeRotar = false;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("activarRotacion", 0.1f);
        }       
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        StartCoroutine("reiniciarRotacion");
    }

    void activarRotacion()
    {
        puedeRotar = true;
    }

    IEnumerator reiniciarRotacion()
    {
        yield return new WaitForSeconds(0.3f);
        puedeRotar = false;
        platformEffector2.rotationalOffset = 0;
    }
}

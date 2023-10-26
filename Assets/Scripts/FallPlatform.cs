using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatform : MonoBehaviour
{
    PlatformEffector2D platformEffector2;
    [SerializeField]bool puedeRotar = false;
    // Start is called before the first frame update
    void Start()
    {
        platformEffector2 = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (puedeRotar)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                platformEffector2.rotationalOffset = 180;
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            puedeRotar = true;
        }       
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        StartCoroutine("reiniciarRotacion");
    }

    IEnumerator reiniciarRotacion()
    {
        yield return new WaitForSeconds(1f);
        puedeRotar = false;
        platformEffector2.rotationalOffset = 0;
    }
}

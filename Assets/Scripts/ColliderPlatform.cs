using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderPlatform : MonoBehaviour
{
    [SerializeField]FallPlatform plat;
    // Start is called before the first frame update
    void Start()
    {
        plat = GetComponentInParent<FallPlatform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            plat.activarRotacion();
        }        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : Interactable
{
    public float fuerza = 1;
    private float countdownMax = 2;
    private float countdownVal = 0;

    Rigidbody2D rb;

    CircleCollider2D circleCollider2D;

    private bool countdownTrigger = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if (countdownTrigger)
        {
            startCountdown();
        }
    }

    public override void interact()
    {
        if (canInteract)
        {
            gameObject.layer = LayerMask.NameToLayer("Interactables");
            rb.bodyType = RigidbodyType2D.Dynamic;
            circleCollider2D.isTrigger = false;
            rb.AddForce(new Vector2(3, 1) * fuerza, ForceMode2D.Impulse);
            countdownTrigger = true;
            canInteract = false;
        }
    }

    void startCountdown()
    {
        countdownVal += Time.deltaTime;
        if (countdownVal > countdownMax)
        {
            countdownTrigger = false;
            countdownVal = countdownMax;
            stopMoving();
        }
    }

    void stopMoving()
    {
        rb.velocity = Vector2.zero;
        circleCollider2D.isTrigger = true;
        rb.bodyType = RigidbodyType2D.Static;
    }
}

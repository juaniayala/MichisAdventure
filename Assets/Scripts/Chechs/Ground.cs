using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour 
{
    
    private bool onGround;
    private float friction;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EvaluateCollision(collision);
        RetrieveFriction(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        EvaluateCollision(collision);
        RetrieveFriction(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        onGround = false;
        friction = 0;
    }
    private void EvaluateCollision(Collision2D colission)
        {
            for(int i=0; i < colission.contactCount; i++)
                {
                    Vector2 normal = colission.GetContact(i).normal;
                    onGround = normal.y > 0.9f;
                }

        }

    private void RetrieveFriction(Collision2D collision)
    {
        PhysicsMaterial2D material = collision.rigidbody.sharedMaterial;

        friction = 0;

        if(material != null)
        {
            friction = material.friction;
        }
    }

    public float GetFriction()
    {
        return friction;
    }

    public bool GetOnGround()
    {
        return onGround;
    }
}

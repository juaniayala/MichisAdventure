using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private bool onWall;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EvaluateCollision(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        EvaluateCollision(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        onWall = false;
    }
    private void EvaluateCollision(Collision2D colission)
    {
        for (int i = 0; i < colission.contactCount; i++)
        {
            Vector2 normal = colission.GetContact(i).normal;
            if(normal.x < -0.9f && normal.x > 0.9f)
            {
                onWall = false;
            }
            else if(normal.x < -0.9f)
            {
                onWall = true;
            }
            else if(normal.x > 0.9f)
            {
                onWall = true;
            }
            else
            {
                onWall = false;
            }
        }
    }


    public bool GetOnWall()
    {
        return onWall;
    }
}

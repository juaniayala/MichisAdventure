using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private InputController input = null;
    [SerializeField, Range(0f, 100f)] private float maxSpeed = 10f;
    [SerializeField, Range(0f, 100f)] private float maxAceleration = 10f;
    [SerializeField, Range(0f, 100f)] private float maxSpeedRunning = 15;
    [SerializeField, Range(0f, 100f)] private float maxAcelerationRunning = 13;
    [SerializeField, Range(0f, 100f)] private float maxAirAceleration = 20f;

    private Vector2 direction;
    [SerializeField] private Vector2 desiredVelocity;
    public Vector2 velocity;
    private Rigidbody2D body;
    private Ground ground;
    private Run running;

    private float maxSpeedChange;
    private float acceleration;
    private bool onGround;
    [SerializeField] private bool canMove = true;

    private bool facingRight = true;

    public ParticleSystem dust;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        ground = GetComponent<Ground>();
        running = GetComponent<Run>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            direction.x = input.RetrieveMoveInput();
            if (running.getIsRunning())
            {
                desiredVelocity = new Vector2(direction.x, 0f) * Mathf.Max(maxSpeedRunning - ground.GetFriction(), 0f);
            }
            else
            {
                desiredVelocity = new Vector2(direction.x, 0f) * Mathf.Max(maxSpeed - ground.GetFriction(), 0f);
            }
            rotateObject();
            movingDust();
        }      
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            onGround = ground.GetOnGround();
            velocity = body.velocity;
            if (running.getIsRunning())
            {
                acceleration = onGround ? maxAcelerationRunning : maxAirAceleration;
            }
            else
            {
                acceleration = onGround ? maxAceleration : maxAirAceleration;
            }

            maxSpeedChange = acceleration * Time.deltaTime;
            velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);

            body.velocity = velocity;
        }      
    }

    void rotateObject()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (!facingRight)
            {
                Flip();
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (facingRight)
            {
                Flip();
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void stopMoving()
    {
        canMove = false;
        body.velocity = new Vector2(0, 0);
    }

    public void continueMoving()
    {
        canMove = true;
    }

    public bool getMove()
    {
        return canMove;
    }

    void movingDust()
    {
        if (onGround && body.velocity.x != 0)
        {
            dust.Play();
        }
    }
}

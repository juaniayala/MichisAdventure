using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    [SerializeField] private InputController input = null;
    [SerializeField, Range(0f, 15f)] private float jumpHeight = 3f;
    [SerializeField, Range(0, 5)] private float maxAirJumps = 1;
    [SerializeField, Range(0f, 5f)] private float downwardMovementMultiplier = 3f;
    [SerializeField, Range(0f, 5f)] private float upwardMovementMultiplier = 3f;
    [SerializeField, Range(0f, 1f)] private float coyoteTime = 0.2f;
    [SerializeField, Range(0f, 1.5f)] private float groundJumpCooldown = 0.5f;

    private Rigidbody2D body;
    private Ground ground;
    private Wall wall;
    private Vector2 velocity;

    [SerializeField]private float groundJumpTimer = 0;
    [SerializeField]private int jumpPhase;
    private float defaultGravityScale;

    private bool desiredJump;
    private bool onGround;
    private bool onWall;
    private bool canGroundJump;

   
    private float coyoteTimeCounter;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        ground = GetComponent<Ground>();
        wall = GetComponent<Wall>();

        defaultGravityScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (onGround || onWall)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (!canGroundJump)
        {
            groundJumpTimer -= Time.deltaTime;
            if (groundJumpTimer <= 0)
            {
                canGroundJump = true;
            }
        }

        desiredJump |= input.RetrieveJumpInput();
    }

    private void FixedUpdate()
    {
        onGround = ground.GetOnGround();
        onWall = wall.GetOnWall();
        velocity = body.velocity;

        if (onGround && canGroundJump)
        {
            jumpPhase = 0;
        }

        if (onWall)
        {
            jumpPhase = 0;
        }

        if (desiredJump)
        {
            desiredJump = false;
            JumpAction();
            coyoteTimeCounter = 0f;
        }

        if(body.velocity.y > 0)
        {
            body.gravityScale = upwardMovementMultiplier;
        }
        else if(body.velocity.y < 0)
        {
            body.gravityScale = downwardMovementMultiplier;
        }
        else if(body.velocity.y == 0)
        {
            body.gravityScale = defaultGravityScale;
        }

        body.velocity = velocity;
    }

    private void JumpAction()
    {
        if(canJump())
        {
            jumpCooldown();
            jumpPhase += 1;
            float jumpSpeed = Mathf.Sqrt(-2f * Physics2D.gravity.y * jumpHeight);
            if(velocity.y > 0f)
            {
                jumpSpeed = Mathf.Max(jumpSpeed - velocity.y, 0f);
            }
            velocity.y += jumpSpeed;
        }    
    }

    bool canJump()
    {
        if (onGround)
        {
            return canGroundJump;
        }
        else if (onWall)
        {
            return (jumpPhase < maxAirJumps) && coyoteTimeCounter > 0f;
        }
        else
        {
            return false;
        }
    }

    void jumpCooldown()
    {
        groundJumpTimer = groundJumpCooldown;
        canGroundJump = false;
    }
}

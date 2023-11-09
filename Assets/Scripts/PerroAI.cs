using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Patrullando,
    Persiguiendo,
    Investigando,
    Durmiendo,
    Alerta,
    YendoADormir
}

public class PerroAI : MonoBehaviour
{
    public State currentState;
    public Vector2 investigationTarget;
    private Rigidbody2D rb;

    // Variables para el patrullaje
    public Transform[] patrolPoints;
    public Transform sleepingPoint;
    private int currentPatrolIndex;
    public float patrolSpeed;
    public float chaseSpeed;

    // Variables de detección del jugador
    public float visionRange;
    public float chaseThreshold;
    private Transform player;

    // Variable de tiempo de alerta e investigación
    public float alertTime = 5f;
    public float chasingTime = 10f;
    public float sleepingTime = 15f;
    [SerializeField]private float timer;

    private bool sleeping = false;
    public Animator anim;
    private bool facingRight = true;

    public GameObject radio;
    public AudioSource ronquidos, dogRage, ladridos;
    public WinAndLose wLose;
    public Timer Reloj;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentState = State.Patrullando;
        currentPatrolIndex = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        facingRight = true;
    }

    void Update()
    {
        switch (currentState)
        {
            case State.Patrullando:
                Patrol();
                CheckForPlayer();
                break;
            case State.Persiguiendo:
                Chase();
                break;
            case State.Investigando:
                Investigate();
                break;
            case State.Durmiendo:
                Sleep();
                break;
            case State.YendoADormir:
                GoingToSleep();
                break;
            case State.Alerta:
                Alert();
                break;
        }
        checkFacing();
    }

    void checkFacing()
    {
        if (rb.velocity.x < 0 && facingRight)
        {
            Flip();
        }
        else if (rb.velocity.x > 0 && !facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Sleep()
    {
        timer += Time.deltaTime;
        if (timer >= sleepingTime)
        {
            sleeping = false;
            currentState = State.Patrullando;
            ronquidos.Stop();
            anim.SetTrigger("Patrolling");
            radio.GetComponent<playSleepMusic>().pauseMusic();
            timer = 0;
        }
    }

    void Patrol()
    {
        Vector2 target = patrolPoints[currentPatrolIndex].position;
        Vector2 patrolDirection = (target - (Vector2)transform.position).normalized;
        rb.velocity = patrolDirection * patrolSpeed;

        if (Vector2.Distance(transform.position, target) < 1f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }

    void Chase()
    {
        if (Vector2.Distance(transform.position, player.position) > chaseThreshold)
        {
            currentState = State.Patrullando;
            anim.SetTrigger("Patrolling");
        }
        else
        {
            Vector2 chaseDirection = (player.position - transform.position).normalized;
            rb.velocity = chaseDirection * chaseSpeed;
            timer += Time.deltaTime;
            if (timer >= chasingTime || rb.velocity.x == 0)
            {
                dogRage.Stop();
                currentState = State.Alerta;
                ladridos.Play();
                timer = 0f;
                Reloj.changeTimeValue();
                rb.velocity = new Vector2(0, 0);
            }
        }
    }

    void Investigate()
    {
        
        Vector2 direction = (investigationTarget - (Vector2)transform.position).normalized;
        rb.velocity = direction * patrolSpeed;

        if (Vector2.Distance(transform.position, investigationTarget) < 0.2f)
        {
            currentState = State.Patrullando;
            anim.SetTrigger("Patroling");
        }
    }

    void Alert()
    {
        // Lógica de activación del trigger del animator
        anim.SetTrigger("Alert");
        timer += Time.deltaTime;
        if (timer >= alertTime)
        {
            ladridos.Stop();
            timer = 0f;
            wLose.perder();      
        }
    }

    void GoingToSleep()
    {
        anim.SetTrigger("Patrolling");
        Vector2 target = sleepingPoint.position;
        Vector2 patrolDirection = (target - (Vector2)transform.position).normalized;
        rb.velocity = patrolDirection * patrolSpeed;

        if (Vector2.Distance(transform.position, target) < 1f)
        {
            currentState = State.Durmiendo;
            rb.velocity = new Vector2(0, 0);
            sleeping = true;
            anim.SetTrigger("Sleeping");
            ronquidos.Play();
        }
    }

    void CheckForPlayer()
    {
        if (Vector2.Distance(transform.position, player.position) < visionRange)
        {
            currentState = State.Persiguiendo;
            anim.SetTrigger("Chasing");
            dogRage.Play();
        }
    }

    public void GoToSleep()
    {
        dogRage.Stop();
        currentState = State.YendoADormir;
    }

    public bool getSleeping()
    {
        return sleeping;
    }
}
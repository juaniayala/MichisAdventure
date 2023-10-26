using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerroIA : MonoBehaviour
{
    public enum State
    {
        Patrullar,
        Perseguir,
        Dormir,
        Ladrar
    }

    public State currentState;

    public Transform[] patrullarPositions = new Transform[3];
    [SerializeField]private int currentPatrolIndex;
    private Transform player;

    public float velocidadPatrullar;
    public float velocidadPerseguir;
    public float velocidadMaximaPerseguir;
    public float distanciaDeDeteccion;

    private Animator animator;

    private float stateTimer;
    private float maxStateTime;

    private Rigidbody2D rb;

    private void Start()
    {
        currentState = State.Patrullar;
        // Inicializa tus posiciones de patrulla aqu�
        //patrullarPositions = new Transform[2]; //Ajusta el tama�o seg�n el n�mero de posiciones
        currentPatrolIndex = 0;

        // Encuentra al jugador
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Encuentra el componente Animator
        animator = GetComponent<Animator>();

        // Establece el tiempo m�ximo para cada estado
        maxStateTime = 60f; // 60 segundos para el estado "Dormir"

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        switch (currentState)
        {
            case State.Patrullar:
                Patrullar(velocidadPatrullar);
                break;
            case State.Perseguir:
                Perseguir(velocidadPerseguir);
                break;
            case State.Dormir:
                Dormir();
                break;
            case State.Ladrar:
                Ladrar();
                break;
        }      
    }

    private void Patrullar(float velocidad)
    {
        // Implementa la l�gica de patrulla aqu�
        // Puedes cambiar a la siguiente posici�n de patrulla despu�s de un tiempo o al alcanzar una posici�n espec�fica, por ejemplo
        // Si llega al final de las posiciones de patrulla, vuelve al principio
        Vector3 obj = new Vector3(patrullarPositions[currentPatrolIndex].position.x, transform.position.y, patrullarPositions[currentPatrolIndex].position.z);
        transform.position = Vector3.MoveTowards(transform.position, obj, velocidad * Time.deltaTime);
        //Debug.Log("Moviendo a" + patrullarPositions[currentPatrolIndex]);
        if (Vector3.Distance(transform.position, player.position) < distanciaDeDeteccion)
        {
            CambiarAPerseguir();
            Debug.Log("persiguiendo");
            return;
        }

        if (Vector3.Distance(transform.position, patrullarPositions[currentPatrolIndex].position) < 1f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrullarPositions.Length;
        }
    }

    private void Perseguir(float fuerza)
    {
        float distanciaAlJugador = Vector3.Distance(transform.position, player.position);

        if (distanciaAlJugador > distanciaDeDeteccion)
        {
            rb.velocity = new Vector2(0F, 0F);
            currentState = State.Patrullar;
            
            // Puedes reiniciar algunos valores relacionados con la persecuci�n aqu� si es necesario
            return; // Sale del m�todo Perseguir si cambia al estado de patrulla
        }

        // Implementa la l�gica de persecuci�n utilizando fuerzas f�sicas
        Vector3 direction = (player.position - transform.position).normalized;
        if (rb.velocity.magnitude < velocidadMaximaPerseguir) // Verifica si la velocidad actual es menor que la velocidad m�xima permitida
        {
            rb.AddForce(direction * fuerza, ForceMode2D.Force);
            Debug.Log("moviendo rb");
        }
    }

    private void Dormir()
    {
        // Implementa la l�gica de dormir aqu�
        stateTimer += Time.deltaTime;
        // Activa la animaci�n de dormir si existe
        if (animator != null)
        {
            animator.SetBool("isSleeping", true);
        }
        // Si el tiempo de dormir ha terminado, cambia al estado de persecuci�n
        if (stateTimer >= maxStateTime)
        {
            currentState = State.Perseguir;
            // Resetea el temporizador
            stateTimer = 0f;
            // Restablece la animaci�n de dormir si existe
            if (animator != null)
            {
                animator.SetBool("isSleeping", false);
            }
        }
    }

    private void Ladrar()
    {
        // Implementa la l�gica de ladrar aqu�
        stateTimer += Time.deltaTime;
        // Activa la animaci�n de ladrar si existe
        if (animator != null)
        {
            animator.SetBool("isBarking", true);
        }
        // Si el tiempo de ladrar ha terminado, cambia al estado de patrulla
        if (stateTimer >= 10f) // 10 segundos para el estado "Ladrar"
        {
            currentState = State.Patrullar;
            // Resetea el temporizador
            stateTimer = 0f;
            // Restablece la animaci�n de ladrar si existe
            if (animator != null)
            {
                animator.SetBool("isBarking", false);
            }
        }
    }

    public void CambiarAPerseguir()
    {
        currentState = State.Perseguir;
    }
}

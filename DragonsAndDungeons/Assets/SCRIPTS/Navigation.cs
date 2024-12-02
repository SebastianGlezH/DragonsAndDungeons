using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NavigationScript : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    private bool shouldFollowPlayer = false;
    private Vector3 originalPosition; // Almacena la posición original
    private float returnDelay = 6.0f; // Tiempo de espera antes de regresar
    private Coroutine returnCoroutine; // Almacena la coroutine para regresar
    public float Cerca = 0.0f;
    public bool isMoving = false;     
    public bool muerte = false;     
    public bool damage = false;     
    Animator animator;
    private string enemyAnimationName = "DS_onehand_attack_A";
    public AudioSource sonidoEnemigo;
    public AudioClip SonidoGolpe;
    public AudioClip SonidoDamage;
    public AudioClip SonidoMuerte;
    public float saludMaxEnemigo = 100f;
    public string etiqueta;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        etiqueta = gameObject.tag;
        originalPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("espada"))
        {
                saludMaxEnemigo -= 20f;
                animator.SetBool("damage", damage);
            Debug.Log("Vida reducida del enemigo: " + saludMaxEnemigo);
            sonidoEnemigo.PlayOneShot(SonidoDamage);
            if(saludMaxEnemigo <= 0){
                muerte = true; 
            animator.SetBool("muerte", muerte);
            sonidoEnemigo.PlayOneShot(SonidoMuerte);
            Collider[] colliders = GetComponents<Collider>();
    foreach (Collider col in colliders)
    {
        col.enabled = false;
    }
    Debug.Log("Colliders desactivados.");
            Destroy(gameObject, 4f);
        }
            }
            
    }

    void Update()
    {
        if(saludMaxEnemigo > 0)
        {
                    if (shouldFollowPlayer && player != null)
        {
            agent.destination = player.position;
            LookAtPlayer();
        }
        }
        // Detecta si debe seguir al jugador


        Cerca = Vector3.Distance(transform.position, player.position);
        animator.SetFloat("Cerca", Cerca);

        if (agent.velocity.sqrMagnitude > 0.01f)
        {
            isMoving = true; 
            animator.SetBool("isMoving", isMoving);
        }
        else
        {
            isMoving = false;
            animator.SetBool("isMoving", isMoving);
        }

        // Obtener el estado actual de la animación en la capa base (índice 0)
        AnimatorStateInfo animStateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // Comprobar si el enemigo está reproduciendo la animación que queremos detectar
        if (animStateInfo.IsName(enemyAnimationName))
        {
            AccionDuranteAnimacion();
        }
    }

    void AccionDuranteAnimacion()
    {
        if (!sonidoEnemigo.isPlaying) // Evitar que se reproduzca varias veces seguidas
        {
            sonidoEnemigo.PlayOneShot(SonidoGolpe);
        }
    }

    private void LookAtPlayer()
    {
        // Calcula la dirección hacia el jugador
        Vector3 direction = player.position - transform.position;
        direction.y = 0;

        if (direction.magnitude > 0.1f) // Verifica que haya distancia suficiente para rotar
        {
            if(agent.CompareTag("Spider")){
                Quaternion lookRotation = Quaternion.LookRotation(-direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * agent.angularSpeed);
            }
            else{
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * agent.angularSpeed);
            }
        }
    }

    public void SetPlayer(Transform playerTransform)
    {
        player = playerTransform; // Asigna la referencia a Player 1
    }

    public void SetShouldFollowPlayer(bool value)
    {
        shouldFollowPlayer = value; // Establece el estado de seguimiento

        if (!value) // Si deja de seguir al jugador
        {
            if (returnCoroutine != null)
                StopCoroutine(returnCoroutine); // Detiene cualquier coroutine en ejecución

            returnCoroutine = StartCoroutine(ReturnToOriginalPosition());
        }
    }

    private IEnumerator ReturnToOriginalPosition()
    {
        yield return new WaitForSeconds(returnDelay); // Espera el tiempo definido

        // Regresa a la posición original
        agent.destination = originalPosition; 

        // Espera hasta llegar a la posición original
        while (Vector3.Distance(transform.position, originalPosition) > 0.1f)
        {
            // Actualiza la rotación en función de la dirección de movimiento
            UpdateRotationTowardsMovement();

            yield return null; // Espera el siguiente frame
        }

        // Establece el destino a la posición original
        agent.ResetPath(); // Limpia el camino del NavMeshAgent
    }

    private void UpdateRotationTowardsMovement()
    {
        Vector3 direction = agent.velocity;
        if (direction.magnitude > 0.1f) // Verifica que haya movimiento
        {
            direction.y = 0; // Mantiene la rotación en el plano horizontal
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * agent.angularSpeed);
        }
    }
}

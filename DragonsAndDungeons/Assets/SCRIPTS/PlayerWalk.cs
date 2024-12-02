using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    public float rotationSpeed = 3f; 

    private PlayerAnimator playerAnim;
    private float h, v;
    public float jumpPower = 200f;
    public LayerMask groundLayer; // Asegúrate de que esto está configurado correctamente
    private bool isGrounded, hasJumped;

    public float speed = 4f;
    private Vector3 velocity;  
    public float gravity = -9.81f;  

    float velocidad = 0.0f;
    public float acceleration = 2f;
    public float deceleration = 10f;

    public AudioSource sonidoPlayer;
    public AudioClip SonidoGolpe;

    private CharacterController controller;

    void Awake()
    {
        playerAnim = GetComponent<PlayerAnimator>();
        controller = GetComponent<CharacterController>(); // Asegúrate de inicializar el CharacterController aquí
    }

    void Update()
    {
        // CheckMovement();
        AnimatePlayer();
        CheckAttack();
        GroundCollisionAndJump();

        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * rotationSpeed, 0); // Rotar según la entrada del mouse


    }

    private void FixedUpdate()
    {
        // Movimiento usando WASD
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * h + transform.forward * v;
        move = move.normalized * speed * Time.deltaTime;

        controller.Move(move); // Aplicar movimiento
    }

    void AnimatePlayer()
    {
        bool runPressed = Input.GetKey(KeyCode.LeftShift);
        if (v != 0 || h != 0)
        {
            if(velocidad < 5f)
        {
            velocidad += Time.deltaTime * acceleration * 20;
            playerAnim.PlayerWalk(velocidad);
            // Debug.Log(runPressed);
            if (runPressed && velocidad < 5f)
        {
            speed = 8f;
            velocidad += Time.deltaTime * acceleration * 20;
        }
        if(!runPressed && velocidad >= 3.0f)
        {
            velocidad = 3.0f; // Limitar la velocidad al dejar de presionar Shift
            speed = 4f;
        }

        }
            
        }
        else
        {
            if(velocidad > 0.0f)
            {
            velocidad -= Time.deltaTime * deceleration * 20;
            playerAnim.PlayerWalk(velocidad); 
            }
            if(velocidad < 0.0f)
        {
            velocidad = 0.0f;
            playerAnim.PlayerWalk(velocidad); 
        } 
        }

        }

    void CheckAttack()
    {
        if (Input.GetMouseButtonDown(0))
{
    playerAnim.PlayerAttack();
    
    // Verifica si el sonido no se está reproduciendo antes de reproducirlo
    if (!sonidoPlayer.isPlaying)
    {
        sonidoPlayer.PlayOneShot(SonidoGolpe);
    }

}
    }

    void GroundCollisionAndJump()
    {
        // Verifica si el controlador está en el suelo
        isGrounded = controller.isGrounded; 

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;  
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        {
            velocity.y = Mathf.Sqrt(jumpPower * -2f * gravity);
            hasJumped = true;
            playerAnim.Jumped(true);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime); 
    }

    void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == "Ground")
        {
            if (hasJumped)
            {
                hasJumped = false;
                playerAnim.Jumped(false);
            }
        }
    }
}

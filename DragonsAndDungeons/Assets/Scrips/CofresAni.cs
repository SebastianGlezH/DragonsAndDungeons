using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class CofresAni : MonoBehaviour
{
    public GameObject CamaraCofre;
    public GameObject texto;
    private bool isPlayerInRange = false; // Verifica si el jugador est� dentro del rango
    public Animator animator;
    public string triggerName = "PlayAnimation";
    public string animationStateName = "NombreDeLaAnimacion";
    public string newTag = "PlayerSalir";
    public GameObject player;

    void Start()
    {
        CamaraCofre.SetActive(false);
        texto.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entr� es el jugador (puedes ajustar seg�n tu necesidad)
        if (other.CompareTag("Player"))
        {
            // Activa el texto
            texto.SetActive(true);
        }

        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica si el objeto que sali� es el jugador
        if (other.CompareTag("Player"))
        {
            // Desactiva el texto
            texto.SetActive(false);
        }

        // Si el jugador sale del rango, cambia el estado de la variable
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    void Update()
    {

        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ChangeTag();
            if (animator != null)
            {
                // Activar el Trigger en el Animator
                animator.SetTrigger(triggerName);
                CamaraCofre.SetActive(true);
                texto.SetActive(false);
                
            }
            
        }

        if (animator != null)
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

            // Verificar si estamos en la animaci�n deseada y si ha terminado
            if (stateInfo.IsName(animationStateName) && stateInfo.normalizedTime >= 1.0f)
            {
                if (CamaraCofre != null && CamaraCofre.activeSelf)
                {
                    CamaraCofre.SetActive(false);
                    
                }
            }
        }
    }

    void ChangeTag()
    {
        if (player != null)
        {
            player.tag = newTag;
        }
        
    }



}

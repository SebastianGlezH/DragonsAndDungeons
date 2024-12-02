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
    private bool isPlayerInRange = false; // Verifica si el jugador está dentro del rango
    public Animator animator;
    public string triggerName = "PlayAnimation";

    void Start()
    {
        CamaraCofre.SetActive(false);
        texto.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entró es el jugador (puedes ajustar según tu necesidad)
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
        // Verifica si el objeto que salió es el jugador
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
        // Si el jugador está dentro del rango y presiona "E"
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Cambia de escena
            texto.SetActive(false);

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (animator != null)
            {
                // Activar el Trigger en el Animator
                animator.SetTrigger(triggerName);
            }
            
        }
    }

    



}

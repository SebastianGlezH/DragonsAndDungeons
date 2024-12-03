using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Textos : MonoBehaviour
{
    public GameObject texto;
    public GameObject texto1;
    public int sceneIndex = 1; // Nombre de la escena a la que quieres cambiar
    private bool isPlayerInRange = false; // Verifica si el jugador est� dentro del rango

    void Start()
    {
        texto1.SetActive(false);
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

        // if (other.CompareTag("Player"))
        // {
        //     // Activa el texto
        //     texto1.SetActive(true);
        // }


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

        if (other.CompareTag("Player"))
        {
            // Desactiva el texto
            texto1.SetActive(false);
        }

        // Si el jugador sale del rango, cambia el estado de la variable
        // if (other.CompareTag("PlayerSalir"))
        // {
        //     isPlayerInRange = false;
        // }
    }


    void Update()
    {
        // Si el jugador est� dentro del rango y presiona "E"
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Cambia de escena
            ChangeScene();
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }



}

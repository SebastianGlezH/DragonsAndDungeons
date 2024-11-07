using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Textos : MonoBehaviour
{
    public GameObject texto;
    public int sceneIndex = 1; // Nombre de la escena a la que quieres cambiar
    private bool isPlayerInRange = false; // Verifica si el jugador está dentro del rango

    void Start()
    {
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
            ChangeScene();
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }



}

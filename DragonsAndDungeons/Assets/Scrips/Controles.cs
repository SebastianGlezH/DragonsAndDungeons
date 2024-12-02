using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controles : MonoBehaviour
{
    public GameObject canvas; // Mapa
    public string targetTag = "SalirNV";
    private bool isPlayerInRange = false;


    void Start()
    {
        // Ocultar el cursor
        Cursor.visible = false;

        // Bloquear el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Mapa
        if (Input.GetKeyDown(KeyCode.M))
        {
            
            canvas.SetActive(!canvas.activeSelf);
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        // Ocultar el cursor nuevamente si se presiona otra tecla (por ejemplo, C)
        if (Input.GetKeyDown(KeyCode.C))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

    }
}

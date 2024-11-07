using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controles : MonoBehaviour
{
    public GameObject canvas; // Mapa
    public string targetTag = "SalirNV";
    private bool isPlayerInRange = false;

    void Update()
    {
        // Mapa
        if (Input.GetKeyDown(KeyCode.M))
        {
            
            canvas.SetActive(!canvas.activeSelf);
        }

    }
}

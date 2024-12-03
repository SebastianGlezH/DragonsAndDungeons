using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Salir : MonoBehaviour
{
    public int targetScene;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Camara"))
        {
            SceneManager.LoadScene(targetScene);
        }
    }

}

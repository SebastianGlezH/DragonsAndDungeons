using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dragon : MonoBehaviour
{

    public GameObject CamaraDrag;
    public Animator animator;
    public string triggerName = "PlayAnimation";
    public string animationStateName = "NombreDeLaAnimacion";

    // Start is called before the first frame update
    void Start()
    {
        CamaraDrag.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entró es el jugador (puedes ajustar según tu necesidad)
        if (other.CompareTag("Player"))
        {
            // Activa el texto
            CamaraDrag.SetActive(true);
            animator.SetTrigger(triggerName);
        }

            // Verifica si el objeto que entró es el jugador (puedes ajustar según tu necesidad
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}

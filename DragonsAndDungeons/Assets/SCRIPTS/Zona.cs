using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTrigger : MonoBehaviour
{
    public List<GameObject> enemies; // Lista de enemigos

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject enemy in enemies)
            {
                NavigationScript navigationScript = enemy.GetComponent<NavigationScript>();
                // navigationScript.SetPlayer(other.transform);
                navigationScript.SetShouldFollowPlayer(true); // Activa la persecución
            }
            Debug.Log("El jugador ha entrado en la zona1, los enemigos están en modo persecución.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject enemy in enemies)
            {
                NavigationScript navigationScript = enemy.GetComponent<NavigationScript>();
                // navigationScript.SetPlayer(null); // Limpia la referencia al jugador
                navigationScript.SetShouldFollowPlayer(false); // Detiene la persecución
            }
            Debug.Log("El jugador ha salido de la zona1, los enemigos han detenido la persecución.");
        }
    }
}
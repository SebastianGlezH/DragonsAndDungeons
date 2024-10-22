using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            EndGame();
        }
    }

    void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("damage"))
    {
        TakeDamage(10);  // Resta 10 puntos de vida
    }
}

    void EndGame()
    {
        // Aquí puedes realizar acciones adicionales antes de finalizar la escena, como animaciones
        Debug.Log("Game Over");

        // Opción 1: Recargar la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Opción 2: Cargar una escena específica, como una pantalla de Game Over
        // SceneManager.LoadScene("GameOverScene");

        // Opción 3: Salir de la aplicación (funciona en build, no en el editor de Unity)
        // Application.Quit();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Health: " + health);
    }

}

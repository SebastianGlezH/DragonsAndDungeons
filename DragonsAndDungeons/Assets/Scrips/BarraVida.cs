using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Asegúrate de incluir esto para cargar escenas

public class BarraVida : MonoBehaviour
{
    public Image Lavida;
    public float saludMaxima = 100f;
    public float porcentajeVida = 100f;
    public bool nuevoGolpe = true;
    public float tiempoentreGolpes;
    public float tiempoGolpe;

    private void Start()
    {
        // Inicialización de vida
        Lavida.fillAmount = porcentajeVida / saludMaxima;
        tiempoGolpe = 0.6f;
        tiempoentreGolpes = 1f;
    }

    private void Update()
    {
        if(nuevoGolpe == false){
            Debug.Log(tiempoGolpe);
            tiempoGolpe -= Time.deltaTime * tiempoentreGolpes;
            if(tiempoGolpe <= 0f)
            {
                nuevoGolpe = true;
                tiempoGolpe = 0.6f;
            }
            }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("QuitarVida") && nuevoGolpe)
        {
            // Reducir vida y actualizar la barra de vida inmediatamente
            porcentajeVida -= 20f;
            Debug.Log("Vida reducida: " + porcentajeVida);
            nuevoGolpe = false;
            ActualizarVida();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("QuitarVida"))
        {
            // Permitir que el jugador reciba otro golpe al salir de la colisión
            
            
        }
    }

    private void ActualizarVida()
    {
        Lavida.fillAmount = porcentajeVida / saludMaxima;
        if (porcentajeVida <= 0)
        {
            // Lógica para manejar la derrota del jugador
            Debug.Log("El jugador ha sido derrotado.");
            FinDelJuego();
        }
    }

    private void FinDelJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // SceneManager.LoadScene("GameOverScene");
    }
}

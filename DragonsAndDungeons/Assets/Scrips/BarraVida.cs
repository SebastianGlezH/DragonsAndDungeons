using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;
using static System.Net.Mime.MediaTypeNames;

public class BarraVida : MonoBehaviour
{

    public Image Lavida;
    public float saludMaxima;
    public float porcentajeVida;

    // Start is called before the first frame update
    private void Start()
    {
        saludMaxima = 100f;
        porcentajeVida = 100f;

    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("QuitarVida"))
        {
            porcentajeVida -= 20f;
        }

    }


    void Update()
    {
        Lavida.fillAmount = porcentajeVida / saludMaxima;
    }


}

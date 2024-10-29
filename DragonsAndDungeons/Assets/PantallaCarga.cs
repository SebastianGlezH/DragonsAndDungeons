using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PantallaCarga : MonoBehaviour
{

    public GameObject PantallaDeCarga;
    public Slider slider;
    public float tiempo = 10f;

    public void CargarNivel(int NumeroEscena)
    {

        StartCoroutine(CargarAsyc(NumeroEscena));

    }

    IEnumerator CargarAsyc(int NumeroEscena)
    {

        AsyncOperation Operacion = SceneManager.LoadSceneAsync(NumeroEscena);

        PantallaDeCarga.SetActive(true);

        while (!Operacion.isDone)
        {
            float Progreso = Mathf.Clamp01(Operacion.progress / .9f);
            slider.value = tiempo;
            yield return null;
        }

       



    }

}

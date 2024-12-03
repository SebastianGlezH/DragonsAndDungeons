using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ObjetoDestruibleScript : MonoBehaviour
{
    public AudioSource sonidoObjeto;
    public AudioClip SonidoDamage;
    public AudioClip SonidoMuerte;
    public float saludObjeto = 100f;
    public string etiqueta;

    void Start()
    {
        etiqueta = gameObject.tag;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("espada"))
        {
                saludObjeto -= 20f;
                
            Debug.Log("Vida reducida del objeto: " + saludObjeto);
            sonidoObjeto.PlayOneShot(SonidoDamage);
            if(saludObjeto <= 0){
            sonidoObjeto.PlayOneShot(SonidoMuerte);
            Destroy(gameObject, 0.1f);
        }
            }
            
    }

    void Update()
    {

    }
}

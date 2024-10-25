using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AniamcionesUI : MonoBehaviour
{
    [SerializeField] public GameObject boton;

    private RectTransform botonRectTransform;

    private void Start()
    {
        botonRectTransform = boton.GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Reproduce la animaci�n cuando el cursor entra al bot�n
        LeanTween.moveX(botonRectTransform, 0, 1.5f).setEase(LeanTweenType.easeOutExpo);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // (Opcional) Puedes agregar una animaci�n para cuando el cursor salga del bot�n
        // Aqu� podr�as devolver el bot�n a su posici�n original si lo deseas, por ejemplo:
        LeanTween.moveX(botonRectTransform, -100, 1.5f).setEase(LeanTweenType.easeOutExpo); // Vuelve el bot�n a la izquierda (-100 es un ejemplo)
    }

}   
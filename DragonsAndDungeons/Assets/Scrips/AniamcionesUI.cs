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
        // Reproduce la animación cuando el cursor entra al botón
        LeanTween.moveX(botonRectTransform, 0, 1.5f).setEase(LeanTweenType.easeOutExpo);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // (Opcional) Puedes agregar una animación para cuando el cursor salga del botón
        // Aquí podrías devolver el botón a su posición original si lo deseas, por ejemplo:
        LeanTween.moveX(botonRectTransform, -100, 1.5f).setEase(LeanTweenType.easeOutExpo); // Vuelve el botón a la izquierda (-100 es un ejemplo)
    }

}   
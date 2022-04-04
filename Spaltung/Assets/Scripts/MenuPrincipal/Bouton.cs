using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Bouton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject background;
    private Image backgroundImage;
    
    public Sprite off;
    public Sprite on;

    public void Awake()
    {
        backgroundImage = background.GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        backgroundImage.sprite = on;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        backgroundImage.sprite = off;
    }
}

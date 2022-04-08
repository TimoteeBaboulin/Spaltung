using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cerfs : MonoBehaviour, Iinteractable
{
    public Vector3 position { get; set; }

    private void Awake()
    {
        position = transform.position;
    }

    public void Interact(Player player)
    {
        DialogueSystem.Instance.Say("Vite, l'Ours s'est réveillé et il arrive! \nLa porte est cadenassée, il faut trouver un code !", "Cerfs");
    }
}

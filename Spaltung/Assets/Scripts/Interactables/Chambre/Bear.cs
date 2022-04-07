using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour, Iinteractable
{
    private void Awake()
    {
        position = transform.position;
    }

    public Vector3 position { get; set; }
    public void Interact(Player player)
    {
        DialogueSystem.Instance.Say("Ma peluche préférée, elle reste tout le temps avec moi. \n C'est mon meilleur ami de tous les temps.");
    }
}

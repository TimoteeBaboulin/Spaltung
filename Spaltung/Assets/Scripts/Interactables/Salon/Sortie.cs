using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sortie : MonoBehaviour, Iinteractable
{
    public Vector3 position { get; set; }
    public GameObject cadenas;
    public bool open;

    private void Awake()
    {
        open = false;
        position = transform.position;
    }

    public void Interact(Player player)
    {
        if (!open) {
            player.StartPause();
            cadenas.SetActive(true);
            return;
        }
        DialogueSystem.instance.Say("Bien joué frere.", "Gilles");
    }
}

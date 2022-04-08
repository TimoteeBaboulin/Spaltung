using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Telecommande : MonoBehaviour, Iinteractable
{
    public Item item;
    public Vector3 position { get; set; }

    private void Awake()
    {
        position = transform.position;
    }

    public void Interact(Player player)
    {
        player.AddItem(item);
        DialogueSystem.Instance.Say("Maman veut pas que je touche à la télécommande normalement.", "Aldjia");
        Destroy(gameObject);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corde : MonoBehaviour, Iinteractable
{
    public Item item;
    public Vector3 position { get; set; }

    private void Awake()
    {
        position = transform.position;
    }

    public void Interact(Player player)
    {
        DialogueSystem.Instance.Say("Je pourrais m'en servir pour faire tomber quelque chose.", "Aldjia");
        player.AddItem(item);
        Destroy(gameObject);
    }
}
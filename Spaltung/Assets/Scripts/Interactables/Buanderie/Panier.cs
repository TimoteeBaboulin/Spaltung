using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panier : MonoBehaviour, Iinteractable
{
    public Item item;
    private void Awake()
    {
        position = transform.position;
    }

    public Vector3 position { get; set; }
    public void Interact(Player player)
    {
        DialogueSystem.Instance.Say("Le panier à linge.", "Alice");
        player.AddItem(item);
        Destroy(gameObject);
    }
}

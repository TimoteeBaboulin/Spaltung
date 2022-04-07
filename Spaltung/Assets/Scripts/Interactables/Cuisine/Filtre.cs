using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filtre : MonoBehaviour, Iinteractable
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
        DialogueSystem.Instance.Say("Un filtre pour le café.", "Alice");
        Destroy(gameObject);
    }
}

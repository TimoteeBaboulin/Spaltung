using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gland : MonoBehaviour, Iinteractable
{
    public Item item;
    public bool state;
    public Vector3 position { get; set; }

    private void Awake()
    {
        state = false;
        position = transform.position;
    }

    public void Interact(Player player)
    {
        if (state) {
            DialogueSystem.Instance.Say("La chaise était bancale, j'espère que ça passera", "Alice");
            player.AddItem(item);
            Destroy(gameObject);
        }
        else
            DialogueSystem.Instance.Say("Il est trop haut pour moi.", "Alice");
    }
}
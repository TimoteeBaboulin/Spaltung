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
        DialogueSystem.Instance.Say("La corde à linge.", "Alice");
        player.AddItem(item);
        Destroy(gameObject);
    }
}
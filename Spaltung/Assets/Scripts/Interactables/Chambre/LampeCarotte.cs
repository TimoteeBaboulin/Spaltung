using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampeCarotte : MonoBehaviour, Iinteractable
{
    public Item item;
    public Vector3 position { get; set; }
    public void Interact(Player player)
    {
        player.AddItem(item);
        DialogueSystem.Instance.Say("Une jolie lampe en forme de carotte.", "Alice");
        Destroy(gameObject);
    }

    private void Awake()
    {
        position = transform.position;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Algue : MonoBehaviour, Iinteractable
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
        DialogueSystem.Instance.Say("Ugh, je déteste avoir la main mouillée.", "Alice");
        Destroy(gameObject);
    }
}

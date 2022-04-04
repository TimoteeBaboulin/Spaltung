using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, Iinteractable
{
    public Vector3 position { get; set; }
    public Item item;
    
    public void Interact(Player player)
    {
        player.AddItem(item);
    }

    private void Awake()
    {
        position = transform.position;
    }
}

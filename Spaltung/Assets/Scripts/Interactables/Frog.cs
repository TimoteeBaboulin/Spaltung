using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour, Iinteractable
{
    public Item key;
    public int keyCount;

    public Item itemGiven;
    
    public Vector3 position { get; set; }

    private void Awake()
    {
        position = transform.position;
    }

    public void Interact(Player player)
    {
        if (player.TakeItem(key))
        {
            keyCount--;
            if (keyCount==0)
                player.AddItem(itemGiven);
            else
                Debug.Log("Still need " + keyCount + " " + key.name + "s.");
        }
        else
        {
            Debug.Log("I don't have the key.'");
        }
    }
    
}


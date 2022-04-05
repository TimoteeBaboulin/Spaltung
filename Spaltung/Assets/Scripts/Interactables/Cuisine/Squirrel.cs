using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel : MonoBehaviour, Iinteractable
{
    public Item key;
    public int keyCount;

    public GameObject chambreManager;

    public Item itemGiven;
    
    public Vector3 position { get; set; }

    private void Awake()
    {
        position = transform.position;
    }

    public void Interact(Player player)
    {
        if (player.TakeItem(key)) {
            keyCount--;
            if (keyCount == 0) {
                player.AddItem(itemGiven);
                chambreManager.GetComponent<ChambreManager>().ecureuil = true;
                DialogueSystem.instance.Say("Tu me donnes une clef?", "Alice");
            }
            else
                DialogueSystem.instance.Say("Mange bien, c'est important.", "Alice");
        }
        else {
            if (keyCount==0) {
                DialogueSystem.instance.Say("Merci pour la clef.", "Alice");
            }
            else
                DialogueSystem.instance.Say("Il a l'air affamé, le pauvre...", "Alice");
        }
    }
    
}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour, Iinteractable
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
                chambreManager.GetComponent<ChambreManager>().grenouille = true;
                DialogueSystem.instance.Say("??? Il y a une clef dans sa bouche.", "Alice");
            }
            else
                DialogueSystem.instance.Say("Voila ton enfant, petite grenouille, prends en soin cette fois.", "Alice");
        }
        else {
            if (keyCount==0) {
                DialogueSystem.instance.Say("Ou as tu trouve cette clef, petite grenouille?", "Alice");
            }
            else
                DialogueSystem.instance.Say("Croak, Croak", "Grenouille");
        }
    }
    
}


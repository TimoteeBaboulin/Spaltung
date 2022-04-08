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
                DialogueSystem.Instance.Say("Il y a une clef dans sa bouche.", "Aldjia");
            }
            else
                DialogueSystem.Instance.Say("Voila ton enfant, petite grenouille, prends en soin cette fois.", "Aldjia");
        }
        else {
            if (keyCount==0) {
                DialogueSystem.Instance.Say("Où as tu trouve cette clef, petite grenouille ?", "Aldjia");
            }
            else
                DialogueSystem.Instance.Say("Croak, Croak", "Grenouille");
        }
    }
    
}


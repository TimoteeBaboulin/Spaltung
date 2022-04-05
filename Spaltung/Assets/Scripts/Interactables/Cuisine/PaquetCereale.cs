using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaquetCereale : MonoBehaviour, Iinteractable
{
    public Item key;

    public Item itemGiven;
    public bool isOpen;

    private bool alreadyUsed;
    public Vector3 position { get; set; }

    private void Awake()
    {
        position = transform.position;
        isOpen = false;
        alreadyUsed = false;
    }

    public void Interact(Player player)
    {
        if (!isOpen) {
            if (player.TakeItem(key)) {
                transform.position = new Vector3(transform.position.x, 0.1f, player.transform.position.z);
                DialogueSystem.instance.Say("J'ai pu faire tomber le paquet avec mon épée", "Alice");
                isOpen = true;
            }
            else {
                DialogueSystem.instance.Say(
                    "Un paquet de mes céréales préférées... elles sont trop hautes pour moi.", "Alice");
            }
        }
        else {
            if (alreadyUsed) {
                DialogueSystem.instance.Say("J'ai tout renversé.", "Alice");
            }
            else {
                player.AddItem(itemGiven);
                alreadyUsed = true;
                DialogueSystem.instance.Say("??? \n Que fait un gland dans les céréales?", "Alice");
            }
        }
    }
}

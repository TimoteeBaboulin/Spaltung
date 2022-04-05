using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baignoire : MonoBehaviour, Iinteractable
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
                DialogueSystem.instance.Say("Il a l'air d'aimer les algues, il s'est calmé directement.", "Alice");
                isOpen = true;
            }
            else {
                DialogueSystem.instance.Say(
                    "Il y a un tetard dans la baignoire, mais il s'enfuit quand j'essaies de l'attraper", "Alice");
            }
        }
        else {
            if (alreadyUsed) {
                DialogueSystem.instance.Say("L'algue est toujours là.", "Alice");
            }
            else {
                player.AddItem(itemGiven);
                alreadyUsed = true;
                DialogueSystem.instance.Say("Hop-la, tu ne m'échapperas pas.", "Alice");
            }
        }
    }
}
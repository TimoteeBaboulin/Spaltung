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
                DialogueSystem.Instance.Say("Il a l'air d'aimer les algues, il s'est calmé directement.", "Aldjia");
                isOpen = true;
            }
            else {
                DialogueSystem.Instance.Say(
                    "Il y a un tetard dans la baignoire, mais il s'enfuit quand j'essaies de l'attraper", "Aldjia");
            }
        }
        else {
            if (alreadyUsed) {
                DialogueSystem.Instance.Say("L'algue est toujours là.", "Aldjia");
            }
            else {
                player.AddItem(itemGiven);
                alreadyUsed = true;
                DialogueSystem.Instance.Say("Hop-la, tu ne m'échapperas pas.", "Aldjia");
            }
        }
    }
}
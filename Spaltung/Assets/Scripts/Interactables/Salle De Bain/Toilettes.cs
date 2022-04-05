using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilettes : MonoBehaviour, Iinteractable
{
    public Item key;

    public Item itemGiven;
    public bool isOpen;
    public Vector3 position { get; set; }

    private void Awake()
    {
        position = transform.position;
        isOpen = false;
    }

    public void Interact(Player player)
    {
        if (!isOpen) {
            if (player.TakeItem(key)) {
                DialogueSystem.instance.Say("Voila, un tétard sans toucher les saletés.", "Alice");
                player.AddItem(itemGiven);
                isOpen = true;
            }
            else {
                DialogueSystem.instance.Say(
                    "Il y a un tétard dans les toilettes... \nJe refuse de mettre la main la dedans.", "Alice");
            }
        }
        else {
            DialogueSystem.instance.Say("Pauvre tétard.", "Alice");
        }
    }
}
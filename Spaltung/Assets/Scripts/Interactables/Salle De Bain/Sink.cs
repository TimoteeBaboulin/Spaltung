using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour, Iinteractable
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
                DialogueSystem.Instance.Say("Le gobelet rentre dans le siphon, ça devrait etre simple d'attraper le tétard maintenant.", "Aldjia");
                isOpen = true;
            }
            else {
                DialogueSystem.Instance.Say(
                    "Un tétard est en train de se faire aspirer par le lavabo. \nIl va trop vite pour moi...", "Aldjia");
            }
        }
        else {
            if (alreadyUsed) {
                DialogueSystem.Instance.Say("Pauvre tétard.", "Aldjia");
            }
            else {
                player.AddItem(itemGiven);
                alreadyUsed = true;
                DialogueSystem.Instance.Say("Je vais te ramener à ta maman.", "Aldjia");
            }
        }
    }
}

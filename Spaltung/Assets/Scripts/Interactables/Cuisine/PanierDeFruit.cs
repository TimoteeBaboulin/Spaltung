using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanierDeFruit : MonoBehaviour, Iinteractable
{
    private bool alreadyGiven;
    public Item item;
    public Vector3 position { get; set; }

    private void Awake()
    {
        alreadyGiven = false;
        position = transform.position;
    }

    public void Interact(Player player)
    {
        if (alreadyGiven) {
            DialogueSystem.Instance.Say("Il n'y a plus rien qui m'intéresse.", "Aldjia");
            return;
        }

        alreadyGiven = true;
        DialogueSystem.Instance.Say("Il y avait un gland sous les fruits.", "Aldjia");
        player.AddItem(item);
    }
}

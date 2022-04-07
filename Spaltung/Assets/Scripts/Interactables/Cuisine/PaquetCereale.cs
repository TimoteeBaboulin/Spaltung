using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaquetCereale : MonoBehaviour, Iinteractable
{
    public Item key;

    public Item itemGiven;
    public bool isOpen;
    public bool chaise;

    public Sprite sprite;

    private bool alreadyUsed;
    public Vector3 position { get; set; }

    private void Awake()
    {
        chaise = false;
        position = transform.position;
        isOpen = false;
        alreadyUsed = false;
    }

    public void Interact(Player player)
    {
        if (!isOpen) {
            if (chaise) {
                if (player.TakeItem(key)) {
                    transform.position = new Vector3(transform.position.x, 0.1f, player.transform.position.z);
                    GetComponent<SpriteRenderer>().sprite = sprite;
                    DialogueSystem.Instance.Say("J'ai pu faire tomber le paquet avec mon épée", "Alice");
                    isOpen = true;
                } else {
                    DialogueSystem.Instance.Say("Meme avec la chaise ca reste trop haut.");
                }
            }
            else {
                DialogueSystem.Instance.Say(
                    "Un paquet de mes céréales préférées... elles sont trop hautes pour moi.", "Alice");
            }
        }
        else {
            if (alreadyUsed) {
                DialogueSystem.Instance.Say("J'ai tout renversé.", "Alice");
            }
            else {
                player.AddItem(itemGiven);
                alreadyUsed = true;
                DialogueSystem.Instance.Say("??? \n Que fait un gland dans les céréales?", "Alice");
            }
        }
    }
}

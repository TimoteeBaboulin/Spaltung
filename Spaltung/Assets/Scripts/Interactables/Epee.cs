using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Epee : MonoBehaviour, Iinteractable
{
    public Item item;
    public Vector3 position { get; set; }

    private void Awake()
    {
        position = transform.position;
    }

    public void Interact(Player player)
    {
        DialogueSystem.instance.Say("Ma vieille épée. Je ne me souviens plus du nombre de fois ou je me suis fait mal en courant avec.", "Alice");
        player.AddItem(item);
        Destroy(gameObject);
    }
}
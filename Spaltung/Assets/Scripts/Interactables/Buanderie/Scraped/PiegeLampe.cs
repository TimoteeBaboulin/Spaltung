using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiegeLampe : MonoBehaviour, Iinteractable
{
    public Item key;
    private SpriteRenderer SpriteRenderer;
    public Vector3 position { get; set; }

    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        position = transform.position;
    }

    public void Interact(Player player)
    {
        if (player.TakeItem(key)) {
            SpriteRenderer.sprite = key.sprite;
            SpriteRenderer.color = Color.white;
            transform.localPosition = new Vector3(transform.localPosition.x, 0.01f, transform.localPosition.z);
            DialogueSystem.instance.Say("La lampe pour le piège.", "Alice");
        }
        else {
            DialogueSystem.instance.Say("Ca semble etre un bon endroit pour le piege.", "Alice");
        }
    }
}

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
            DialogueSystem.Instance.Say("La lampe pour le piège.", "Aldjia");
        }
        else {
            DialogueSystem.Instance.Say("Ça semble être un bon endroit pour le piège.", "Aldjia");
        }
    }
}

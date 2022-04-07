using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : MonoBehaviour, Iinteractable
{
    public Vector3 position { get; set; }

    private void Awake()
    {
        position = transform.position;
    }

    public void Interact(Player player)
    {
        DialogueSystem.Instance.Say("Salut petit lapin, tu voudrais bien me passer cette clef?");
    }
}

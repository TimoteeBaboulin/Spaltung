using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Livre : MonoBehaviour, Iinteractable
{
    public GameObject livreUI;
    public Vector3 position { get; set; }

    private void Awake()
    {
        position = transform.position;
    }

    public void Interact(Player player)
    {
        player.StartPause();
        livreUI.SetActive(true);
    }
}

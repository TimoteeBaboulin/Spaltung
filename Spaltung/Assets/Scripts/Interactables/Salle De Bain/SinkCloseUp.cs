using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkCloseUp : MonoBehaviour, Iinteractable
{
    public GameObject sinkUI;
    public Vector3 position { get; set; }

    private void Awake()
    {
        position = transform.position;
    }

    public void Interact(Player player)
    {
        player.StartPause();
        sinkUI.SetActive(true);
    }
}

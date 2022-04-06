using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaignoireCloseUp : MonoBehaviour, Iinteractable
{
    public GameObject baignoireUI;
    public Vector3 position { get; set; }

    private void Awake()
    {
        position = transform.position;
    }

    public void Interact(Player player)
    {
        player.StartPause();
        baignoireUI.SetActive(true);
    }
}

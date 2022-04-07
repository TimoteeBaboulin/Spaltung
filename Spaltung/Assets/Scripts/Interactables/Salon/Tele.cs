using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tele : MonoBehaviour, Iinteractable
{
    public GameObject televisionUI;
    public Item key;
    public Vector3 position { get; set; }

    private void Awake()
    {
        position = transform.position;
    }

    public void Interact(Player player)
    {
        if (player.TakeItem(key))
        {
            player.StartPause();
            televisionUI.SetActive(true);
            return;
        }
        DialogueSystem.Instance.Say("La télé est éteinte.");
    }
}

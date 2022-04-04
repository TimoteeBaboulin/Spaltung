using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouloirDoor : MonoBehaviour, Iinteractable
{
    public Item key;
    public GameObject couloirPorte;

    private bool _isOpen;
    public Vector3 position { get; set; }

    private void Awake()
    {
        position = transform.position;
        _isOpen = false;
    }

    public void Interact(Player player)
    {
        if (!_isOpen)
        {
            if (player.TakeItem(key))
            {
                _isOpen = true;
            }
            else
            {
                Debug.Log("I need a key");
            }

            return;
        }

        LevelManager.levelManager.ChangeLevel("Couloir", couloirPorte.transform.position);
    }
    
}

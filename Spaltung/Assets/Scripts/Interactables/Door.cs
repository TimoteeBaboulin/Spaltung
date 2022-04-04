using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Iinteractable
{
    public Item key;
    public GameObject autrePorte;

    public bool _isOpen;
    private Level nextLevel;
    public Vector3 position { get; set; }

    private void Awake()
    {
        position = transform.position;
        nextLevel = autrePorte.GetComponentInParent<Level>(true);
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

        LevelManager.levelManager.ChangeLevel(nextLevel.name, autrePorte.transform.position);
    }
    
}

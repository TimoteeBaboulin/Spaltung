using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Iinteractable
{
    public int keyCount;
    public Item key;
    public GameObject autrePorte;
    public string lockedText;

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
        if (!_isOpen) {
            if (player.TakeItem(key)) {
                keyCount--;
                if (keyCount == 0) {
                    DialogueSystem.Instance.Say("Porte dévérouillée.", "Porte");
                    _isOpen = true;
                } else {
                    DialogueSystem.Instance.Say("Il me faut encore " + keyCount + " clefs.", "Aldjia");
                }
            } else {
                DialogueSystem.Instance.Say(lockedText, "Aldjia");
            }

            return;
        }

        LevelManager.levelManager.ChangeLevel(nextLevel.name, autrePorte.transform.position);
    }

    public void UpdateDoor()
    {
        nextLevel = autrePorte.GetComponentInParent<Level>(true);
    }
    
}

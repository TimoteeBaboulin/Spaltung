using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetardUI : MonoBehaviour
{
    public bool cup;
    public Item item;

    private void Awake()
    {
        cup = false;
    }

    public void CupSet()
    {
        cup = true;
    }

    public void AttemptCatch()
    {
        if (cup) {
            Player.Instance.AddItem(item);
            DialogueSystem.Instance.Say("Je vais te ramener a ta maman.", "Alice");
            Destroy(gameObject);
        } else {
            DialogueSystem.Instance.Say("Le tetard va trop vite.", "Alice");
        }
    }
    
}

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
            DialogueSystem.Instance.Say("Je vais te ramener à ta maman.", "Aldjia");
            Destroy(gameObject);
        } else {
            DialogueSystem.Instance.Say("Le tétard va trop vite.", "Aldjia");
        }
    }
    
}

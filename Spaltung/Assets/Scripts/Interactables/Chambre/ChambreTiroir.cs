using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ChambreTiroir : MonoBehaviour, Iinteractable
{
    private bool alreadyUsed = false;
    public Item item;
    private void Awake()
    {
        position = transform.position;
    }

    public Vector3 position { get; set; }
    public void Interact(Player player)
    {
        if (!alreadyUsed)
        {
            Player.current.AddItem(item);
            alreadyUsed = true;
            DialogueSystem.instance.Say("J'ai trouvé une clef dans mon tiroir.", "Alice");
        }
        else DialogueSystem.instance.Say("Il n'y a plus rien à trouver ici.", "Alice");
    }
}

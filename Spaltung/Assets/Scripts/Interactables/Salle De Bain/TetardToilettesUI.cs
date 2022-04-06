using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetardToilettesUI : MonoBehaviour
{
    public Item key;
    public Item item;
    
    public void AttemptCatch()
    {
        if (Player.current.TakeItem(key)) {
            Player.current.AddItem(item);
            Destroy(gameObject);
            return;
        }
        DialogueSystem.instance.Say("Je ne mets pas ma main la-dedans.", "Alice");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetardToilettesUI : MonoBehaviour
{
    public Item key;
    public Item item;
    
    public void AttemptCatch()
    {
        if (Player.Instance.TakeItem(key)) {
            Player.Instance.AddItem(item);
            Destroy(gameObject);
            return;
        }
        DialogueSystem.Instance.Say("Je ne mets pas ma main la-dedans.", "Alice");
    }
}

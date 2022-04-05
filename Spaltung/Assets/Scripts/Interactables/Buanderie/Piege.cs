using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piege : MonoBehaviour, Iinteractable
{
    public List<Item> keys;
    public List<Sprite> sprites;
    public Vector3 position { get; set; }

    private void Awake()
    {
        position = transform.position;
    }

    public void Interact(Player player)
    {
        if (keys.Count > 0) {
            if (player.TakeItem(keys[0])) {
                keys.Remove(keys[0]);

                List<Item> newList = new List<Item>();
                foreach (var item in keys)
                {
                    if (item!=null)
                        newList.Add(item);
                }
                keys = newList;
                
                DialogueSystem.instance.Say("Prout");
            } else
            {
                DialogueSystem.instance.Say("Je devrais trouver comment attirer le lapin.", "Alice");
            }
        } else {
            DialogueSystem.instance.Say("IT WORKS!!!");
        }
    }
}

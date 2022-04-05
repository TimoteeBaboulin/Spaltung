using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piege : MonoBehaviour, Iinteractable
{
    public List<Item> keys;
    public List<Sprite> sprites;

    public Item item;
    
    private bool alreadyTaken;

    private SpriteRenderer sprite;
    public Vector3 position { get; set; }

    private void Awake()
    {
        position = transform.position;
        sprite = GetComponent<SpriteRenderer>();
    }

    public void Interact(Player player)
    {
        if (keys.Count > 0) {
            if (player.TakeItem(keys[0])) {
                sprite.sprite = sprites[0];
                sprites.Remove(sprites[0]);
                
                keys.Remove(keys[0]);

                List<Item> newList = new List<Item>();
                foreach (var item in keys)
                {
                    if (item!=null)
                        newList.Add(item);
                }
                keys = newList;
                
                List<Sprite> newSpriteList = new List<Sprite>();
                foreach (var item in sprites)
                {
                    if (item!=null)
                        newSpriteList.Add(item);
                }
                sprites = newSpriteList;
                
                DialogueSystem.instance.Say("Prout");
            } else {
                DialogueSystem.instance.Say("Je devrais trouver comment attirer le lapin.", "Alice");
            }
        } else {
            if (alreadyTaken) {
                DialogueSystem.instance.Say("Désolé, pauvre lapinou.", "Alice");
            } else {
              DialogueSystem.instance.Say("Désolé, mais il me fallait cette clef.", "Alice");
              player.AddItem(item);
            }
        }
    }
}

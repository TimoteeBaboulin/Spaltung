using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piege : MonoBehaviour, Iinteractable
{
    public List<Item> keys;
    public List<Sprite> sprites;

    public Item item;
    public GameObject bunny;
    
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
                sprite.color = Color.white;
                sprites.Remove(sprites[0]);
                
                keys.Remove(keys[0]);

                List<Item> newList = new List<Item>();
                foreach (var item in keys)
                {
                    if (item!=null)
                        newList.Add(item);
                }
                keys = newList;

                if (keys.Count == 0) {
                    bunny.SetActive(false);
                    return;
                }
                
                List<Sprite> newSpriteList = new List<Sprite>();
                foreach (var item in sprites)
                {
                    if (item!=null)
                        newSpriteList.Add(item);
                }
                sprites = newSpriteList;
            } else {
                DialogueSystem.Instance.Say("Je devrais trouver comment attirer le lapin.", "Aldjia");
            }
        } else {
            if (alreadyTaken) {
                DialogueSystem.Instance.Say("Désolé, pauvre lapinou.", "Aldjia");
            } else {
              DialogueSystem.Instance.Say("Désolé, mais il me fallait cette clef.", "Aldjia");
              player.AddItem(item);
              alreadyTaken = true;
            }
        }
    }
}

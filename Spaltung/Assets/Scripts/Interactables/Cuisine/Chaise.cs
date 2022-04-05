using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaise : MonoBehaviour, Iinteractable
{
    private bool state;
    public GameObject unlockGO;
    private Gland unlock;
    
    private void Awake()
    {
        unlock = unlockGO.GetComponent<Gland>();
        position = transform.position;
        state = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 position { get; set; }
    public void Interact(Player player)
    {
        if (!state) {
            state = true;
            DialogueSystem.instance.Say("Cette chaise est lourde a pousser.", "Alice");
            transform.localPosition = new Vector3(2,0.1f, 1.6f);
            unlock.state = true;
            position = transform.position;
            return;
        }
        DialogueSystem.instance.Say("Maintenant je peut atteindre en hauteur.", "Alice");
    }
}

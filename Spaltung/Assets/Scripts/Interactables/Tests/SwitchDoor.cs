using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDoor : MonoBehaviour, Iinteractable
{
    private bool state;
    public Vector3 position { get; set; }
    public string nextLevel;

    private void Awake()
    {
        position = transform.position;
        state = false;
    }

    public void Interact(Player player)
    {
        if (!state)
        {
            Debug.Log("The door is shut tight");

            return;
        }

        GameObject.FindWithTag("Level Manager").GetComponent<LevelManager>().ChangeLevel(nextLevel);
    }

    public void ChangeState()
    {
        state = !state;
    }
}

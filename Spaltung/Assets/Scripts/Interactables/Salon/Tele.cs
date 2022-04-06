using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tele : MonoBehaviour, Iinteractable
{
    public GameObject televisionUI;
    public Vector3 position { get; set; }

    private void Awake()
    {
        position = transform.position;
    }

    public void Interact(Player player)
    {
        player.StartPause();
        televisionUI.SetActive(true);
    }
}

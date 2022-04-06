using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanierFruitCloseUp : MonoBehaviour, Iinteractable
{
    public GameObject PanierUI;
    public Vector3 position { get; set; }

    private void Awake()
    {
        position = transform.position;
    }

    public void Interact(Player player)
    {
        player.StartPause();
        PanierUI.SetActive(true);
    }
}

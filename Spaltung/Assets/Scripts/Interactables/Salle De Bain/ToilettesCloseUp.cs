using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToilettesCloseUp : MonoBehaviour, Iinteractable
{
    public GameObject toiletteUI;
    public Vector3 position { get; set; }

    private void Awake()
    {
        position = transform.position;
    }

    public void Interact(Player player)
    {
        player.StartPause();
        toiletteUI.SetActive(true);
    }
}

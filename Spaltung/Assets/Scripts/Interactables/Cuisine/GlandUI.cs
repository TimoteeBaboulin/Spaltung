using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlandUI : MonoBehaviour
{
    public bool libre;
    public Item item;

    private void Awake()
    {
        libre = false;
    }

    public void AttemptTake()
    {
        if (libre) {
            Player.Instance.AddItem(item);
            Destroy(gameObject);
            return;
        }
    }
}

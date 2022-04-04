using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private string name;

    private void Awake()
    {
        name = gameObject.name;
    }
}

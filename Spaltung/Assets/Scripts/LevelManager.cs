using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : MonoBehaviour
{
    static public LevelManager levelManager;
    static public string current;
    public List<GameObject> scenes;

    private void Start()
    {
        levelManager = this;
        foreach (var scene in GetComponentsInChildren<Level>(true))
        {
            if (scene.isActiveAndEnabled)
                current = scene.name;
            scenes.Add(scene.gameObject);
        }
    }

    public bool ChangeLevel(string levelName)
    {
        foreach (var scene in scenes)
        {
            if (scene.name == levelName)
            {
                GameObject.Find(current).SetActive(false);
                current = levelName;
                scene.SetActive(true);
                GetComponent<NavMeshSurface2d>().BuildNavMesh();
                return true;
            }
        }

        return false;
    }
    
    public bool ChangeLevel(string levelName, Vector3 position)
    {
        foreach (var scene in scenes)
        {
            if (scene.name == levelName)
            {
                GameObject.Find(current).SetActive(false);
                current = levelName;
                scene.SetActive(true);
                GetComponent<NavMeshSurface2d>().BuildNavMesh();
                
                NavMeshHit hit;
                NavMesh.SamplePosition(position, out hit, 20, -1);
                Player.Instance.GetComponent<NavMeshAgent>().Warp(hit.position);

                return true;
            }
        }

        return false;
    }
}

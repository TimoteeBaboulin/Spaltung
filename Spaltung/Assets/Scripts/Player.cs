using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public static Player current;
    
    public float speed;
    public float depth;

    public bool pause = false;
    
    private NavMeshAgent _navMeshAgent;
    public static Action OnInventoryUpdate;

    [SerializeField]
    public List<Item> inventory;
    
    // Start is called before the first frame update
    void Start()
    {
        current = this;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateUpAxis = false;
        _navMeshAgent.updateRotation = false;
        
        inventory = new List<Item>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!pause)
            {
                DialogueSystem.instance.StopSpeaking();

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit;
                hit = Physics2D.GetRayIntersection(ray);

                Iinteractable interactable = hit.collider.GetComponent<Iinteractable>();

                if (interactable != null)
                {
                    StartCoroutine(InteractWith(interactable));
                }
                else
                {
                    MoveTo(hit.point);
                }
            }
            else DialogueSystem.instance.StopSpeaking();

        }
        Rescale();
        
       
    }

    void MoveTo(Vector3 destination)
    {
        NavMeshHit hit;
        
        NavMesh.SamplePosition(destination, out hit, 20, -1);
        _navMeshAgent.speed = speed;
        _navMeshAgent.SetDestination(hit.position);
    }

    void Rescale()
    {
        float size = 0.75f - transform.position.y * 0.1f * depth;
        transform.localScale = new Vector3(size, size, 0);
    }

    IEnumerator InteractWith(Iinteractable interactable)
    {
        NavMeshHit hit;
        NavMesh.SamplePosition(interactable.position, out hit, 20, -1);
        do
        {
            MoveTo(hit.position);
            yield return null;
        } while (_navMeshAgent.remainingDistance > _navMeshAgent.stoppingDistance);
        interactable.Interact(this);

    }

    public void AddItem(Item item)
    {
        inventory.Add(item);
        Player.OnInventoryUpdate.Invoke();
    }

    public bool TakeItem(Item item)
    {
        if (!inventory.Contains(item))
            return false;
        inventory.Remove(item);
        Player.OnInventoryUpdate.Invoke();
        return true;
    }
}



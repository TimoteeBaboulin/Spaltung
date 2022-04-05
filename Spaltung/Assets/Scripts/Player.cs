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
    private bool closeUp;
    
    private NavMeshAgent _navMeshAgent;
    private Animator Animator;
    private SpriteRenderer SpriteRenderer;
    
    public static Action OnInventoryUpdate;

    private Coroutine coroutine;

    [SerializeField]
    public List<Item> inventory;
    
    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
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
            if (!pause && !closeUp)
            {
                if (coroutine != null)
                    StopCoroutine(coroutine);
                DialogueSystem.instance.StopSpeaking();

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit;
                hit = Physics2D.GetRayIntersection(ray);

                Iinteractable interactable = hit.collider.GetComponent<Iinteractable>();

                if (interactable != null)
                {
                    coroutine = StartCoroutine(InteractWith(interactable));
                }
                else
                {
                    MoveTo(hit.point);
                }
            }
            else DialogueSystem.instance.StopSpeaking();

        }
        Rescale();

        SpriteRenderer.flipX = (_navMeshAgent.velocity.x <= 0 && _navMeshAgent.remainingDistance > 0);
        Animator.SetBool("Going Right", _navMeshAgent.velocity.x >= 0);
        Animator.SetBool("Moving", _navMeshAgent.remainingDistance > 0);
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

    public void StartPause()
    {
        closeUp = true;
    }

    public IEnumerator StopPause()
    {
        yield return new WaitForEndOfFrame();
        closeUp = false;
    }

    public void StopPauseButton()
    {
        StartCoroutine(StopPause());
    }
}



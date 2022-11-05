using System;
using UnityEngine;

[RequireComponent(typeof(PathFollower), typeof(InteractionChecker), typeof(Animator))]
[RequireComponent(typeof(EnemyPointer), typeof(Rigidbody))]
public class NPCMajor : NPCBase
{
    
    [SerializeField] private DroppedItem[] objectsToDrop;
    [SerializeField] private GameObject disguiseItem;

    private InteractionChecker interatorWithPlayer;
    private Animator animator;
    protected PathFollower pathFollower;
    private bool isDeath = false;


    private void Start()
    {
        animator = GetComponent<Animator>();
        pathFollower = GetComponent<PathFollower>();
        interatorWithPlayer = GetComponent<InteractionChecker>();
        interatorWithPlayer.InteractionStartWithPlayer += OnStartInteractionWithPlayer;
        interatorWithPlayer.InteractionCompleted += OnInteractWitPlayerCompleted;
    }

    private void OnStartInteractionWithPlayer(Transform player)
    {
        if (!isDeath)
        {
            player.GetComponent<PlayerInteractController>().GetAnimator().SetTrigger("Attack");

        }
        else if(isDeath)
        {
            player.GetComponent<PlayerInteractController>().GetAnimator().SetTrigger("Pick Up");
        }
    }

    private void OnInteractWitPlayerCompleted(Transform player)
    {
        if (!isDeath)
        {
            Death();
            animator.SetTrigger("Death");
        }
        else
        {
            DisguiseBody();
        }
    }

    protected override void Death()
    {
        NPCDeath?.Invoke();
        
        DropItems();
        pathFollower.enabled = false;
        isDeath = true;
/*        base.Death();*/
    }

    private void DisguiseBody()
    {
        Instantiate(disguiseItem, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void DropItems()
    {
        Vector3 spawnOffset = new Vector3(0.5f, 0, 0);
        for (int i = 0; i < objectsToDrop.Length; i++)
        {
            Instantiate(objectsToDrop[i], transform.position + spawnOffset * i, Quaternion.Euler(0, UnityEngine.Random.Range(0, 180), 0));
            Debug.Log(objectsToDrop[i].name + " dropped");
        }
    }


    protected override void StopSurrender()
    {
        pathFollower.enabled = true;
        base.StopSurrender();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PathFollower), typeof(InteractionChecker))]
public class NPCMajor : NPCBase
{
    [SerializeField] private DroppedItem[] objectsToDrop;
    [SerializeField] private InteractionChecker interatorWithPlayer;
    protected PathFollower pathFollower;

    private void Start()
    {
        pathFollower = GetComponent<PathFollower>();
        interatorWithPlayer.InterectWIthPlayerAction += OnInteractWitPlayer;
    }

    private void OnInteractWitPlayer(Transform player)
    {
        Death();
    }

    protected override void Death()
    {
        DropItems();
        base.Death();
    }

    private void DropItems()
    {
        Vector3 spawnOffset = new Vector3(0.5f, 0, 0);
        for (int i = 0; i < objectsToDrop.Length; i++)
        {
            Instantiate(objectsToDrop[i], transform.position + spawnOffset * i, Quaternion.Euler(0, Random.Range(0, 180), 0));
            Debug.Log(objectsToDrop[i].name + " dropped");
        }
    }

    protected override void Surrender()
    {
        pathFollower.enabled = false;
        base.Surrender();
    }

    protected override void StopSurrender()
    {
        pathFollower.enabled = true;
        base.StopSurrender();
    }
}

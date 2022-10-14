using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PathFollower))]
public class NPCMajor : NPCBase
{
    [SerializeField] private DroppedItem[] objectsToDrop;
    protected PathFollower pathFollower;

    private void Start()
    {
        pathFollower = GetComponent<PathFollower>();
    }

    protected override void Death()
    {
        DropItems();
        base.Death();
    }

    private void DropItems()
    {
        foreach (var obj in objectsToDrop)
        {
            Instantiate(obj);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAfterDeathDrop : MonoBehaviour
{
    [SerializeField] private DroppedItem[] DeathDrop;

    public void DropItems()
    {
        foreach (DroppedItem item in DeathDrop)
        {
            Instantiate(item);
        }
    }
}

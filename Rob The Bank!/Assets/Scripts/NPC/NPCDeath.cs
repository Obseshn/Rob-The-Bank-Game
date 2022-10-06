using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDeath : MonoBehaviour
{
    [SerializeField] private DroppedObject[] objectsToDrop;

    public void KillNPC()
    {
        if (objectsToDrop.Length > 0)
        {
            foreach (var drop in objectsToDrop)
            {
                Instantiate(drop);
            }
        }

        Debug.Log("NPC died");
        Destroy(gameObject);
    }
}

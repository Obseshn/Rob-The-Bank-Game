using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(InteractionChecker))]
public class NPCSurrenderRoom : MonoBehaviour
{
    [SerializeField] private BoxCollider collider;
    private InteractionChecker interactor;
    private void Start()
    {
        collider = GetComponent<BoxCollider>();
        collider.isTrigger = true;
        interactor = GetComponent<InteractionChecker>();
        interactor.InteractionStartWithPlayer += ScareAllIdleNPCInRoom;
    }

    private void ScareAllIdleNPCInRoom(Transform player)
    {
        if (player.GetComponent<PlayerInteractController>().GetStateOfPistol())
        {
            Collider[] idleNPC = Physics.OverlapBox(transform.position, collider.size);
            Debug.Log(idleNPC.Length + " !!!!!!");
            foreach (var npc in idleNPC)
            {
                if (npc.transform.GetComponent<NPCIdle>())
                {
                    npc.GetComponent<NPCIdle>().Surrender();
                    Debug.Log("ROBBER WITH GUN IN THE BANK");
                }
            }
            Destroy(gameObject);
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, collider.size);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class NPCDoorOpener : MonoBehaviour
{
    [SerializeField] private buttonActivateSwivel_gjm controlledDoor;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PathFollower>())
        {
            controlledDoor.OpenDoorForNPC();
            Debug.Log("NPC door open!");
        }
    }
}

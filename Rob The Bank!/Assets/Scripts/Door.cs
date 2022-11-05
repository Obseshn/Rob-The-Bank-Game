using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractionChecker), typeof(Rigidbody))]
public class Door : MonoBehaviour
{
    enum DoorType
    {
        noKeyDoor,
        stuffKeyDoor,
        keyCardDoor,
        codeKeyDoor
    }

    [SerializeField] private DoorType doorType;
    [SerializeField] private InteractionChecker interactor;
    private void Start()
    {
        interactor.InteractionStartWithPlayer += OnInteractWithPlayer;
    }

    public void OpenDoor()
    {
        Debug.Log("Door has been opened!" + "Doortype: " + doorType);
    }

    private void OnInteractWithPlayer(Transform sender)
    {
        if (doorType == DoorType.noKeyDoor)
        {
            OpenDoor();
        }
        else
        {
            PlayerInventory playerInv = sender.GetComponent<PlayerInventory>();
            if (doorType == DoorType.stuffKeyDoor && playerInv.GetBoolStateOfStuffKey())
            {
                OpenDoor();
                return;
            }
            if (doorType == DoorType.keyCardDoor && playerInv.GetBoolStateOfKeyCard())
            {
                OpenDoor();
                return;
            }
            if (doorType == DoorType.codeKeyDoor && playerInv.GetBoolStateOfCodeKey())
            {
                OpenDoor();
                return;
            }
        }
    }
}

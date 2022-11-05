using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider), typeof(Outline))]
public class DroppedItem : MonoBehaviour
{
    [SerializeField] private Items itemName;
    [SerializeField] private InteractionChecker playerInteractor;


    private BoxCollider collider;

    private void Start()
    {
        collider = GetComponent<BoxCollider>();
        collider.isTrigger = true;
        playerInteractor.InteractionStartWithPlayer += OnInteractWithPlayer;
    }

    public Items GetItemName()
    {
        return itemName;
    }

    private void OnInteractWithPlayer(Transform sender)
    {
        sender.GetComponent<PlayerInventory>().AddItem(GetComponent<DroppedItem>());
        sender.GetComponent<PlayerInteractController>().PickUpAnimation();
    }
/*    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerInventory>().AddItem(transform.GetComponent<DroppedItem>());
        }
    }*/
}

public enum Items
{
    OfficerWearing,
    StuffKey,
    KeyCard,
    Pistol,
    Code
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractionChecker))]
public class Money : MonoBehaviour
{
    [SerializeField] private InteractionChecker interactor;

    private void Start()
    {
        interactor.InteractionStartWithPlayer += OnInteractionStart;
        interactor.InteractionCompleted += OnInteractionCompleted;
    }

    private void OnInteractionStart(Transform player)
    {
        if (player.GetComponent<MoneyBag>().HasEmptySlots())
        {
            player.GetComponent<PlayerInteractController>().GetAnimator().SetTrigger("TakeMoney");
            player.GetComponent<PlayerInventory>().ShowOrHideBag(true);
        }
        else
        {
            interactor.CancelInteractWithPlayer(player);
        }
    }

    private void OnInteractionCompleted(Transform player)
    {
        MoneyBag playerBag = player.GetComponent<MoneyBag>();
        player.GetComponent<PlayerInventory>().ShowOrHideBag(false);

        if (playerBag.HasEmptySlots())
        {
            playerBag.GetComponent<MoneyBag>().AddMoney(1);
            Destroy(gameObject);
        }
    }
}

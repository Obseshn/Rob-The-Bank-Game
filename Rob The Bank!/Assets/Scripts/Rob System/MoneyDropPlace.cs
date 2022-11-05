using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(InteractionChecker))]
public class MoneyDropPlace : MonoBehaviour
{
    [SerializeField] private int collectedBagsOfMoney = 0;
    [SerializeField] private int bagsToCompleteLevel = 5;
    private InteractionChecker interactionChecker;

    private void Start()
    {
        interactionChecker = GetComponent<InteractionChecker>();
        interactionChecker.InteractionStartWithPlayer += OnInteractionStart;
        interactionChecker.InteractionCompleted += OnInteractionComlpeted;
    }

    private void OnInteractionStart(Transform player)
    {
        if (player.GetComponent<MoneyBag>().GetCurrentMoneySlots() > 0)
        {
            player.GetComponent<PlayerInteractController>().GetAnimator().SetTrigger("Pick Up");
        }
        else
        {
            interactionChecker.CancelInteractWithPlayer(player);
        }
        
    }

    private void OnInteractionComlpeted(Transform player)
    {
        MoneyBag playerMoneyBag = player.GetComponent<MoneyBag>();
        collectedBagsOfMoney += playerMoneyBag.GetCurrentMoneySlots();
        playerMoneyBag.RemoveMoney(playerMoneyBag.GetCurrentMoneySlots());

        if (collectedBagsOfMoney >= bagsToCompleteLevel)
        {
            Debug.Log("LEVEL COMPLETED");
        }
    }
}

using System;
using System.Collections;
using UnityEngine;


public class InteractionChecker : MonoBehaviour
{
    public Action<Transform> InteractionStartWithPlayer;
    /*public Action<Transform> CanceleInteractionWithPlayer;*/
    public Action<Transform> InteractionCompleted;

    private bool isOnInteracting;

    [SerializeField] private float interactionTime = 3f;

    public float GetInteractionTime()
    {
        return interactionTime;
    }

    private void Start()
    {
        InteractionCompleted += LetPlayerMove;
    }

    private void LetPlayerMove(Transform player)
    {
        player.GetComponent<StarterAssets.ThirdPersonController>().MoveSpeed = 4;
    }
    IEnumerator InteractionCounter(float timeInSec, Transform interactor)
    {
        isOnInteracting = true;
        yield return new WaitForSeconds(interactionTime);
        if (isOnInteracting)
        {
            InteractionCompleted?.Invoke(interactor);
        }
    }
    public void InteractWithPlayer(Transform interactor)
    {
        if (isOnInteracting == false)
        {
            Debug.Log(transform.name + " interacted with player!");
            InteractionStartWithPlayer?.Invoke(interactor);
            interactor.GetComponent<StarterAssets.ThirdPersonController>().MoveSpeed = 0;
            StartCoroutine(InteractionCounter(interactionTime, interactor));
        }
        else
        {
            CancelInteractWithPlayer(interactor);
        }
    }

    public void CancelInteractWithPlayer(Transform interactor)
    {
        isOnInteracting = false;
        interactor.GetComponent<PlayerInteractController>().GetAnimator().SetTrigger("GoToIdle");
        LetPlayerMove(interactor);
    }
}




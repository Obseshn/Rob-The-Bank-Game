using System;
using UnityEngine;

public class InteractionChecker : MonoBehaviour
{
    public Action<Transform> InterectWIthPlayerAction;
    public void InteractWithPlayer(Transform interator)
    {
        Debug.Log(transform.name + " interacted with player!");
        InterectWIthPlayerAction?.Invoke(interator);
    }
}

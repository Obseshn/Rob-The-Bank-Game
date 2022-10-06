using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private float counter = 0;
    private float maxDetectionProgress = 5f;

    private bool isPlayerInTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (isPlayerInTrigger)
        {
            counter += Time.deltaTime;
            if (counter >= maxDetectionProgress)
            {
                Debug.Log("Player has been detected!");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        counter = 0;
        isPlayerInTrigger = false;
    }
}

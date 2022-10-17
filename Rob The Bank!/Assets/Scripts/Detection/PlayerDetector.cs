using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private float counter = 0;
    private int maxDetectionProgress = 5;
    private bool isPlayerDetected;

    public void PlayerDetectedState(bool newState)
    {
        isPlayerDetected = newState;
    }

    private void Update()
    {
        if (isPlayerDetected)
        {
            if (counter == maxDetectionProgress)
            {
                Debug.Log(transform.name + " fully detect a player!");
            }
            counter += Time.deltaTime;
        }
        else if(counter > 0)
        {
            counter -= Time.deltaTime * 2;
        }
    }

    /*    IEnumerator PlayerDetectionProgress(int maxTimeInSec)
        {
            float checkRate = 0.5f;
            counter += checkRate;
            for (int i = 0; i < maxTimeInSec / checkRate; i++)
            {
                yield return new WaitForSeconds(checkRate);
                counter += checkRate;
                Physics.Raycast();
            }
        }*/
}

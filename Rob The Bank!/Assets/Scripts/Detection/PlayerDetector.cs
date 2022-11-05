using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private float counter = 0;
    [SerializeField] private int maxDetectionProgress = 5;
    public bool isPlayerDetected;

    public void ResetCounter()
    {
        counter = 0;
    }


    private void Update()
    {
        if (isPlayerDetected)
        {
            if (counter >= maxDetectionProgress)
            {
                Debug.Log(transform.name + " fully detect a player!");
                return;
            }
            counter += Time.deltaTime;
        }
        else if(counter > 0)
        {
            counter -= Time.deltaTime * 2;
        }
    }

    public float GetDetectionInPercent()
    {
        return counter / maxDetectionProgress;
    }
}

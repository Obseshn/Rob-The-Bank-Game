using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDisabler : MonoBehaviour
{
    [SerializeField] private InteractionChecker interactor;
    [SerializeField] private EnemyPointer enemyPointer;
    [SerializeField] private PlayerDetector playerDetector;
    [SerializeField] private Outline outline;

    private void Start()
    {
        interactor.InteractionStartWithPlayer += OnInteractionStart;
        interactor.InteractionCompleted += OnInteractionCompleted;
    }

    private void OnInteractionStart(Transform player)
    {
        // player anim
    }

    private void OnInteractionCompleted(Transform player)
    {
        StartCoroutine(OffCamereOnTime(60));
    }

    IEnumerator OffCamereOnTime(float timeInSec)
    {
        playerDetector.ResetCounter();
        enemyPointer.enabled = false;
        playerDetector.enabled = false;
        outline.OutlineColor = Color.green;
        
        yield return new WaitForSeconds(timeInSec);

        enemyPointer.enabled = true;
        playerDetector.enabled = true;
        outline.OutlineColor = Color.red;
    }
}

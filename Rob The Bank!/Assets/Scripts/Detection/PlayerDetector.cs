using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private float detectingRadius;

    private float counter = 0;
    private float maxDetectionProgress = 5f;

    private bool isPlayerInTrigger;

    private void Start()
    {
        SphereCollider collider = GetComponent<SphereCollider>();
        collider.radius = detectingRadius;
        collider.isTrigger = true;
    }

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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + new Vector3(0, 0, 2), detectingRadius);
    }
}

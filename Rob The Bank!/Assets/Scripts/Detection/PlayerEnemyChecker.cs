using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class PlayerEnemyChecker : MonoBehaviour
{
    [SerializeField] private float radius = 1f;
    private SphereCollider sCollider;

    private void Start()
    {
        sCollider = GetComponent<SphereCollider>();
        sCollider.radius = radius;
        sCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerDetector>())
        {
            RaycastHit raycastHit;
            Vector3 direction = other.transform.position - transform.position;
            Physics.Raycast(transform.position, direction, out raycastHit);

            Debug.Log(raycastHit.transform.name);
            if (raycastHit.transform.GetComponent<PlayerDetector>() == other.GetComponent<PlayerDetector>())
            {
                other.GetComponent<PlayerDetector>().PlayerDetectedState(true);
                Debug.Log(other.name + " went in enemy checker radius");
            }
        }
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerDetector>())
        {
            other.GetComponent<PlayerDetector>().PlayerDetectedState(false);
        }
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

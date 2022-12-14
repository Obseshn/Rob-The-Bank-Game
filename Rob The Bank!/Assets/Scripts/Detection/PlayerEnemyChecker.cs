using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class PlayerEnemyChecker : MonoBehaviour
{
    [SerializeField] private float radius = 1f;
    [SerializeField] private Vector3 offset;
    private SphereCollider sCollider;

    private void Start()
    {
        sCollider = GetComponent<SphereCollider>();
        sCollider.radius = radius;
        sCollider.isTrigger = true;
        sCollider.center += offset;
        InvokeRepeating("CheckEnemyInDetectRadius", 5, 2);
    }

    private void CheckEnemyInDetectRadius()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position + offset, radius);
        foreach (var enemy in enemies)
        {
            if (enemy.GetComponent<EnemyPointer>())
            {
                DrawRayToEnemy(enemy.transform);
            }
        }
    }

    private void DrawRayToEnemy(Transform enemy)
    {
        RaycastHit raycastHit;
        Vector3 direction = enemy.position - transform.position;

        Debug.DrawRay(transform.position, direction, Color.green, 3f);
        if (Physics.Raycast(transform.position + offset, direction, out raycastHit))
        {
            Debug.Log(raycastHit.transform.name);

            if (raycastHit.point.magnitude < direction.magnitude)
            {
                Debug.Log("Raycast point less then direction vector");
                return;
            }

            if (raycastHit.transform.GetComponent<EnemyPointer>())
            {
                enemy.GetComponent<EnemyPointer>().isNearToPlayer = true;
                enemy.GetComponent<PlayerDetector>().isPlayerDetected = true;
                Debug.Log(enemy.name + " went in enemy checker radius");
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<EnemyPointer>())
        {
            other.GetComponent<EnemyPointer>().isNearToPlayer = false;
            other.GetComponent<PlayerDetector>().isPlayerDetected = false;
            /*PointerManager.Instance.RemoveFromList(other.GetComponent<EnemyPointer>());*/
            Debug.Log(other.name + " went out of enemy checker radius");
        }
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + offset, radius);
    }
}

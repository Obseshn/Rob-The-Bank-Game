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
        InvokeRepeating("CheckEnemyInDetectRadius", 5, 5);
    }

    private void CheckEnemyInDetectRadius()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position + offset, radius);
        foreach (var enemy in enemies)
        {
            if (enemy.GetComponentInChildren<EnemyPointer>())
            {
                DrawRayToEnemy(enemy.transform);
            }
        }
    }

    private void DrawRayToEnemy(Transform enemy)
    {
        RaycastHit raycastHit;
        Vector3 direction = enemy.position - transform.position;

        if (Physics.Raycast(transform.position + offset, direction, out raycastHit))
        {
            Debug.Log(raycastHit.transform.name);

            if (raycastHit.point.magnitude < direction.magnitude)
            {
                return;
            }

            if (raycastHit.transform.GetComponentInChildren<EnemyPointer>())
            {
                enemy.GetComponentInChildren<EnemyPointer>().isNearToPlayer = true;
                Debug.Log(enemy.name + " went in enemy checker radius");
            }
        }
        Debug.DrawRay(transform.position, direction, Color.green, 3f);
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInChildren<EnemyPointer>())
        {
            other.GetComponentInChildren<EnemyPointer>().isNearToPlayer = false;
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

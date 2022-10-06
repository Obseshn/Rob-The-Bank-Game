using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    private float attackCD = 5f;
    [SerializeField]private float attackRadius;
    [SerializeField] private Vector3 offset;
    [SerializeField] private LayerMask NPCLayer;
    private bool isReadyToAttack = false;

    private void Start()
    {
        StartCoroutine(AttackCDCounter());
    }

    public void AttackTarget()
    {
        if (isReadyToAttack)
        {
            Collider[] targets = Physics.OverlapSphere(transform.position + offset, attackRadius, NPCLayer);
            Debug.Log(targets.Length);
            if (targets.Length > 0)
            {
                targets[Random.Range(0, targets.Length)].GetComponent<NPCDeath>().KillNPC();
                Debug.Log("Player attacked: " + targets[Random.Range(0, targets.Length)].name);
            }

            StartCoroutine(AttackCDCounter());
        }
        else
        {
            Debug.LogError("Attack CD!");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + offset, attackRadius);
    }

    IEnumerator AttackCDCounter()
    {
        isReadyToAttack = false;
        yield return new WaitForSeconds(attackCD);
        isReadyToAttack = true;
        Debug.Log("Player ready to attack");
    }
}

using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Animator), typeof(CapsuleCollider))]

public class NPCIdle : NPCBase
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Surrender()
    {
        animator.SetTrigger("Surrender");
        NPCDeath?.Invoke();
    }
}

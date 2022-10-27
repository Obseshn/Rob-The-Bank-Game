using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomIdle : StateMachineBehaviour
{
    [SerializeField] private int countOfAnimations;

    // OnStateMachineEnter is called when entering a state machine via its Entry Node
    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        animator.SetInteger("animID", Random.Range(0, countOfAnimations * 3));
    }
}

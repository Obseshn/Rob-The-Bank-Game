using UnityEngine;
using System.Collections;

public class NPCIdle : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private int animationsCount;
    private float minDuration = 10f;

    private void Start()
    {
        
    }

    IEnumerator RandomDurationBetweenAnimations()
    {
        if (Random.Range(0, 2) == 0) // T or false
        {
            yield return new WaitForSeconds(Random.Range(minDuration, minDuration * 3)); // 3 is just a koeff
        }

        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour {

    [HideInInspector]
    public UnityEvent OnDie;

    private void OnCollisionEnter(Collision collision) {
        Die();
    }

    void Die() {
        Destroy(gameObject);
        OnDie.Invoke();
    }

}

using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class EnemyPointer : MonoBehaviour {

    [SerializeField] EnemyHealth _enemyHealth;
    public bool isNearToPlayer;

    private void Start() {
        _enemyHealth.OnDie.AddListener(Destroy);
        PointerManager.Instance.AddToList(this);
    }


    private void Destroy() {
        PointerManager.Instance.RemoveFromList(this);
    }

}

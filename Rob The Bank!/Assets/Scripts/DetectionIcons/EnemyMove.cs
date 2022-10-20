using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    [SerializeField] float _speed = 2;

    Transform _target;
    
    void Start() {
        _target = FindObjectOfType<Player>().transform;
    }

    void Update() {
        Vector3 toTarget = _target.position - transform.position;
        Vector3 toTargetXZ = new Vector3(toTarget.x, 0, toTarget.z);
        Quaternion rotation = Quaternion.LookRotation(toTargetXZ, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 5f);
        transform.Translate(0, 0, Time.deltaTime * _speed);
    }

}

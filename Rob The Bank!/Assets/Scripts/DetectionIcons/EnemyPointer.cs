using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class EnemyPointer : MonoBehaviour {

    [SerializeField] private NPCMajor controllerNPC;
    public bool isNearToPlayer;

    private void Start() {
        controllerNPC.NPCDeath += Destroy;
        PointerManager.Instance.AddToList(this);
    }


    private void Destroy() {
        PointerManager.Instance.RemoveFromList(this);
        
    }

}

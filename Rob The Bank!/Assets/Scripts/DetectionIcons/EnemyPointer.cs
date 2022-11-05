using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

[RequireComponent(typeof(Outline), typeof(PlayerDetector))]
public class EnemyPointer : MonoBehaviour {

    [SerializeField] private NPCBase controllerNPC;
    public bool isNearToPlayer;

    private void Start() {
        controllerNPC.NPCDeath += Destroy;
        PointerManager.Instance.AddToList(this);
        
    }


    private void Destroy() {
        PointerManager.Instance.RemoveFromList(this);
    }

}

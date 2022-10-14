using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBase : MonoBehaviour
{
    protected bool isSurrender;
    protected virtual void Death()
    {
        Debug.Log("NPC died");
        Destroy(gameObject);
    }
    protected virtual void NotifyPolice()
    {
        Debug.Log(transform.name + " had notified police about robber!!!");
    }
    protected virtual void Surrender()
    {
        Debug.Log(transform.name + " had scared and then surrender!");
        isSurrender = true;
    }

    protected virtual void StopSurrender()
    {
        Debug.Log(transform.name + " is't surrender anymore!");
        isSurrender = true;
    }
}

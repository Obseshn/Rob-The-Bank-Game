using System;
using UnityEngine;

public class NPCBase : MonoBehaviour
{
    public Action NPCDeath;
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

    protected virtual void StopSurrender()
    {
        Debug.Log(transform.name + " is't surrender anymore!");
        isSurrender = true;
    }
}

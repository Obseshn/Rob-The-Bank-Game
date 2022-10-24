using UnityEngine;
using System.Collections;
using System;

public class NPCIdle : NPCBase
{
    public Action OnSurrender;
    private void Start()
    {
        OnSurrender += Surrender;
    }
    public override void Surrender()
    {
        base.Surrender();
    }

}

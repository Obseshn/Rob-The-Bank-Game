using UnityEngine;

public class NPCDefender : NPCMajor
{
    private bool isDefenceMode;

    protected override void Surrender()
    {
        isDefenceMode = true;
        pathFollower.enabled = false;
    }

    private void ShootInPlayer()
    {
        Debug.Log(transform.name + " shoot into player!");
    }

    private void RunToPlayer()
    {
        
        Debug.Log(transform.name + " run into player!");
    }
}

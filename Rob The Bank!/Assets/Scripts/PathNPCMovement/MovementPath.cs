using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPath : MonoBehaviour
{
    public enum PathTypes
    {
        linear,
        loop
    }

    public PathTypes PathType;
    public int movementDirection = 1;
    public int moveingTo = 0; // к какой точке джвигаться
    public Transform[] PathElements;



    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        if (PathElements == null || PathElements.Length < 2)
        {
            return;
        }

        for (int i = 1; i < PathElements.Length; i++)
        {
            Gizmos.DrawLine(PathElements[i - 1].position, PathElements[i].position);
        }

        if (PathType == PathTypes.loop)
        {
            Gizmos.DrawLine(PathElements[0].position, PathElements[PathElements.Length - 1].position);
        }
    }
    public IEnumerator<Transform> GetNextPathPoint()
    {
        if (PathElements == null || PathElements.Length < 1)
        {
            yield break;
        }

        while (true)
        {
            yield return PathElements[moveingTo];

            if (PathElements.Length == 1)
            {
                continue;
            }

            if (PathType == PathTypes.linear)
            {
                if (moveingTo <= 0)
                {
                    movementDirection = 1;
                }
                else if (moveingTo >= PathElements.Length - 1)
                {
                    movementDirection = -1;
                }
            }

            moveingTo += movementDirection;

            if (PathType == PathTypes.loop)
            {
                if (moveingTo >= PathElements.Length)
                {
                    moveingTo = 0;
                }

                if (moveingTo < 0)
                {
                    moveingTo = PathElements.Length - 1;
                }
            }
        }
    }
}

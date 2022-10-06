using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public enum MovementType
    {
        Moveing,
        Lerping
    }

    public MovementType type = MovementType.Moveing;
    public MovementPath MyPath;
    public float moveSpeed = 1f;
    private float rotationSpeed = 1f;
    public float maxDistance = .1f;

    private IEnumerator<Transform> pointInPath;

    private bool isOnPointWaiting = false;
    private float pauseBetweenPointsTime = 10f;

    private void Start()
    {
        if (MyPath == null)
        {
            Debug.Log(transform.name + ":  �� ���������� ����(MyPath)");
            return;
        }

        pointInPath = MyPath.GetNextPathPoint();

        pointInPath.MoveNext();

        if (pointInPath.Current == null)
        {
            Debug.Log(transform.name + ": ��� ������ �����");
            return;
        }

        transform.position = pointInPath.Current.position; // ������ ��������� �� 1-� �����
    }

    private void Update()
    {
        if (!isOnPointWaiting)
        {
            if (pointInPath == null || pointInPath.Current == null)
            {
                Debug.Log(transform.name + ": " + "pointInPath: " + pointInPath + "currentPointInPath: " + pointInPath.Current);
                return;
            }

            if (type == MovementType.Moveing)
            {
                transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * moveSpeed);

            }
            else if (type == MovementType.Lerping)
            {
                transform.position = Vector3.Lerp(transform.position, pointInPath.Current.position, Time.deltaTime * moveSpeed);
            }

            var distanceSquare = (transform.position - pointInPath.Current.position).sqrMagnitude;
            if (distanceSquare < maxDistance * maxDistance)
            {
                StartCoroutine(PauseBetweenPointsMoving());
                Debug.Log("Got to point");
                pointInPath.MoveNext();
            }
        }
        else
        {
            Vector3 directon = pointInPath.Current.position - transform.position;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(directon), rotationSpeed * Time.deltaTime);
        }
        
    }

    IEnumerator PauseBetweenPointsMoving()
    {
        isOnPointWaiting = true;
        yield return new WaitForSeconds(pauseBetweenPointsTime);
        isOnPointWaiting = false;
    }
}

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
    public float speed = 1f;
    public float maxDistance = .1f;

    private IEnumerator<Transform> pointInPath;

    private void Start()
    {
        if (MyPath == null)
        {
            Debug.Log(transform.name + ":  не установлен путь(MyPath)");
            return;
        }

        pointInPath = MyPath.GetNextPathPoint();

        pointInPath.MoveNext();

        if (pointInPath.Current == null)
        {
            Debug.Log(transform.name + ": нет нужной точки");
            return;
        }

        transform.position = pointInPath.Current.position; // Объект тпшитьбся на 1-ю точку
    }

    private void Update()
    {
        if (pointInPath == null || pointInPath.Current == null)
        {
            Debug.Log(transform.name + ": " + "pointInPath: " + pointInPath + "currentPointInPath: " + pointInPath.Current);
            return;
        }

        if (type == MovementType.Moveing)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
        }
        else if (type == MovementType.Lerping)
        {
            transform.position = Vector3.Lerp(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
        }

        var distanceSquare = (transform.position - pointInPath.Current.position).sqrMagnitude;
        if (distanceSquare < maxDistance * maxDistance)
        {
            pointInPath.MoveNext();
        }
    }
}

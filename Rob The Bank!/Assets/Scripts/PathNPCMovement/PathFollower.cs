using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{


    [SerializeField] private Animator animator;
    [SerializeField] private MovementPath myPath;
    public enum MovementType
    {
        Moveing,
        Lerping
    }

    [SerializeField] private MovementType type = MovementType.Moveing;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float rotationSpeed = 1f;
    private float maxDistance = .1f;

    private IEnumerator<Transform> pointInPath;

    public Transform GetCurrentPoint()
    {
        return pointInPath.Current;
    }

    private bool isOnPointWaiting = false;
    private float pauseBetweenPointsTime = 10f;

    private void Start()
    {
        if (myPath == null)
        {
            Debug.Log(transform.name + ":  не установлен путь(MyPath)");
            return;
        }

        pointInPath = myPath.GetNextPathPoint();

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
                if (pointInPath.Current.GetComponent<PathPoint>().isPause)
                {
                    rotationSpeed = 1f;
                    StartCoroutine(PauseBetweenPointsMoving(pauseBetweenPointsTime));
                }
                else
                {
                    rotationSpeed = 2f;
                    StartCoroutine(PauseBetweenPointsMoving(pauseBetweenPointsTime / 3f));
                }
                
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

    IEnumerator PauseBetweenPointsMoving(float pauseTime)
    {
        animator.SetBool("isWalking", false);
        isOnPointWaiting = true;
        yield return new WaitForSeconds(pauseTime);
        isOnPointWaiting = false;
        animator.SetBool("isWalking", true);
    }
}

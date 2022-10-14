using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class PathPoint : MonoBehaviour
{
    private BoxCollider collider;

    [SerializeField] public bool isPause = true;
    private float sizeOfCollider = 0.2f;

    private void Start()
    {
        collider = GetComponent<BoxCollider>();
        collider.isTrigger = true;
        collider.size = new Vector3(sizeOfCollider, sizeOfCollider, sizeOfCollider);
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PathFollower>().GetCurrentPoint() == transform)
        {
            if (isPause)
            {
                other.GetComponent<PathFollower>().StartPointPause();
            }
        }
    }*/
}

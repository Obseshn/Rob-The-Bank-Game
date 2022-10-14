using System.Collections;
using UnityEngine;

public class PlayerInteractController : MonoBehaviour
{
    private float interactCD = 5f;
    [SerializeField] private float interactRadius;
    [SerializeField] private Vector3 offset;
    [SerializeField] private LayerMask NPCLayer;
    private bool isReadyToInteract = false;
    private PlayerAdditionalControl input;

    private void Awake()
    {
        input = new PlayerAdditionalControl();
    }

    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }

    private void Start()
    {
        StartCoroutine(InteractCDCounter());
        input.PlayerInteraction.Interact.performed += context => OnInteractButtonPressed();
    }



    private void OnInteractButtonPressed()
    {
        if (isReadyToInteract)
        {
            Collider[] objects = Physics.OverlapSphere(transform.position + offset, interactRadius);
            if (objects.Length > 0)
            {
                foreach (var item in objects)
                {
                    if (item.GetComponent<InteractionChecker>())
                    {
                        item.GetComponent<InteractionChecker>().InteractWithPlayer(transform);
                        break;
                    }
                }
                StartCoroutine(InteractCDCounter());
            }
            else
            {
                Debug.Log("Haven't any interactable object near player!");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + offset, interactRadius);
    }

    IEnumerator InteractCDCounter()
    {
        isReadyToInteract = false;
        yield return new WaitForSeconds(interactCD);
        isReadyToInteract = true;
        Debug.Log("Player ready to attack");
    }
}

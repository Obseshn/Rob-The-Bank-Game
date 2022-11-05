using System.Collections;
using UnityEngine;

public class PlayerInteractController : MonoBehaviour
{
    [SerializeField] private float interactRadius;
    [SerializeField] private float surrenderRadius;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Animator animatior;
    [SerializeField] private PlayerInventory playerInventory;

    public Animator GetAnimator()
    {
       return animatior;
    }

    private float interactCD = 1f;
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
        input.PlayerInteraction.Interact.canceled += ñontext => OnInteractionButtonCanceled();
        input.PlayerInteraction.ShowHideGun.performed += context => OnGunButtonPressed();
    }

    public bool GetStateOfPistol()
    {
        return animatior.GetBool("isGunShowed");
    }

    private void OnGunButtonPressed()
    {
        if (playerInventory.GetPistolBool())
        {
            bool newState = !animatior.GetBool("isGunShowed");
            if (newState)
            {
                animatior.SetTrigger("ShowGun");
            }
            else
            {
                animatior.SetTrigger("HideGun");
            }
            animatior.SetBool("isGunShowed", newState);
            playerInventory.ShowOrHidePistol(newState);
        }
       
    }

    /*IEnumerator DurationBetweenNPCSurrenderChecking(float timeInSec)
    {
        Collider[] objects = Physics.OverlapSphere(transform.position + offset, surrenderRadius);
        foreach (var obj in objects)
        {
            if (obj.GetComponent<NPCBase>())
            {
                obj.GetComponent<NPCIdle>().OnSurrender?.Invoke();
            }
        }
        yield return new WaitForSeconds(timeInSec);
    }*/

    public void PickUpAnimation()
    {
        animatior.SetTrigger("Pick Up");
    }
    private void CheckNPCForSurrender()
    {

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

    IEnumerator InteractionProgress(float timeInSec, InteractionChecker interactItem)
    {
        yield return new WaitForSeconds(timeInSec);
        interactItem.InteractWithPlayer(transform);
    }

    private void OnInteractionButtonCanceled()
    {

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDoor : MonoBehaviour
{
    enum DoorType
    {
        noKeyDoor,
        stuffKeyDoor,
        keyCardDoor,
        codeKeyDoor
    }

    [SerializeField] private DoorType doorType;

    public GameObject swivelAxis;


    private Animator swivelAnnimation;

    bool buttonStatus;

    bool buttonMessage;

    [SerializeField] private InteractionChecker interactor;

    public void OpenDoorForNPC()
    {
        swivelAnnimation.SetTrigger("OpenDoor");
        StartCoroutine(DoorLockDuration(4f));

    }

    private void OnInteractWithPlayer(Transform sender)
    {
        if (doorType == DoorType.noKeyDoor)
        {
            swivelAnnimation.SetTrigger("OpenDoor");
            StartCoroutine(DoorLockDuration(3f));
            return;
        }
        else
        {
            PlayerInventory playerInv = sender.GetComponent<PlayerInventory>();
            if (doorType == DoorType.stuffKeyDoor && playerInv.GetBoolStateOfStuffKey())
            {
                swivelAnnimation.SetTrigger("OpenDoor");
                StartCoroutine(DoorLockDuration(3f));
                return;
            }
            if (doorType == DoorType.keyCardDoor && playerInv.GetBoolStateOfKeyCard())
            {
                swivelAnnimation.SetTrigger("OpenDoor");
                StartCoroutine(DoorLockDuration(3f));
                return;
            }
            if (doorType == DoorType.codeKeyDoor && playerInv.GetBoolStateOfCodeKey())
            {
                GetComponent<CodeUnlock>().ShowCodeMenu();
                return;
            }
        }
        Debug.Log("DoorType: " + doorType);
    }

    void OnGUI()
    {
        //GUI.Label(new Rect(10, 10, 140, 20), "Airspeed:" + VT + " m/s");

        if (buttonMessage)
        {
            //GUI.Label(new Rect(10, 10, 140, 20), "buttonStatus: " + swivelAnnimation.GetBool("buttonDown"));
            //GUI.Label(new Rect(10, 20, 140, 20), "* PRESS BUTTON TO ACTIVATE SWIVEL. ");

            GUI.Label(new Rect(10, 10, 700, 700), "* Press E To Activate.");

            
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        swivelAnnimation = swivelAxis.GetComponent<Animator>();
        interactor.InteractionStartWithPlayer += OnInteractWithPlayer;
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<NPCMajor>())
        {
            swivelAnnimation.SetTrigger("OpenDoor");
            StartCoroutine(DoorLockDuration(7f));
        }

    }


    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerInteractController>())
        {
            buttonMessage = true;
        }
        
        /*if (Input.GetKey("e"))
        {
            swivelAnnimation.SetBool("buttonDown", true);
        }*/
    }


    void OnTriggerExit(Collider other)
    {
        //swivelAnnimation.SetBool("buttonDown", false);
        buttonMessage = false;
        /*swivelAnnimation.SetBool("buttonDown", false);*/
        /*StartCoroutine(DoorLockDuration(3f));*/
    }

    IEnumerator DoorLockDuration(float durationInSec)
    {
        
        yield return new WaitForSeconds(durationInSec);
        swivelAnnimation.ResetTrigger("OpenDoor");
        swivelAnnimation.SetTrigger("CloseDoor");
    }
}

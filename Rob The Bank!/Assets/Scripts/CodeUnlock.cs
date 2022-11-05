using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class CodeUnlock : MonoBehaviour
{
    [SerializeField] private GameObject codeMenu;
    [SerializeField] private GameObject codeErrorMenu;
    [SerializeField] private ButtonDoor controlledDoor;
    [SerializeField] private InputField inputField;


    private readonly string code = "9121522521191261";

    private void Start()
    {
        codeMenu.SetActive(false);
        codeErrorMenu.SetActive(false);
    }
    public void ShowCodeMenu()
    {
        codeMenu.SetActive(true);
        StarterAssets.StarterAssetsInputs playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<StarterAssets.StarterAssetsInputs>();
        playerInput.cursorLocked = false;
        playerInput.cursorInputForLook = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void CheckCode()
    {
        if (inputField.text == code)
        {
            controlledDoor.OpenDoorForNPC();
            codeMenu.SetActive(false);
            codeErrorMenu.SetActive(false);
            StarterAssets.StarterAssetsInputs playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<StarterAssets.StarterAssetsInputs>();
            playerInput.cursorLocked = true;
            playerInput.cursorInputForLook = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            codeMenu.SetActive(true);
            codeErrorMenu.SetActive(true);
        }
    }

}

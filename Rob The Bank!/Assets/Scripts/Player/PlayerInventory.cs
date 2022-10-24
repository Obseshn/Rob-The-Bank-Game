using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private bool hasKeyCard;
    [SerializeField] private bool hasOfficerWear;
    [SerializeField] private bool hasCodeKey;
    [SerializeField] private bool hasPistol;
    [SerializeField] private bool hasStuffKey;

    [Header("Visible objects: ")]
    [SerializeField] private GameObject pistol;
    [SerializeField] private GameObject officerHead;
    [SerializeField] private GameObject defaultHead;

    public bool GetBoolStateOfKeyCard()
    {
        return hasKeyCard;
    }
    public bool GetBoolStateOfStuffKey()
    {
        return hasStuffKey;
    }
    public bool GetBoolStateOfCodeKey()
    {
        return hasCodeKey;
    }

    public bool GetPistolBool()
    {
        return hasPistol;
    }

    public void ShowOrHidePistol(bool state)
    {
        pistol.SetActive(state);
    }

    public void AddItem(DroppedItem item)
    {
        Items pickedItem = item.GetItemName();
        if (pickedItem == Items.KeyCard)
        {
            hasKeyCard = true;
        }
        if (pickedItem == Items.OfficerWearing)
        {
            hasOfficerWear = true;
            defaultHead.SetActive(false);
            officerHead.SetActive(true);
        }
        if (pickedItem == Items.Code)
        {
            hasCodeKey = true;
        }
        if (pickedItem == Items.Pistol)
        {
            hasPistol = true;
            pistol.SetActive(true);
        }
        if (pickedItem == Items.StuffKey)
        {
            hasStuffKey = true;
        }
        Destroy(item.gameObject);
    }


}

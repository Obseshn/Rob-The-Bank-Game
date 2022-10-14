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

    public void AddItem(DroppedItem item)
    {
        Items pickerItem = item.GetItemName();
        if (pickerItem == Items.KeyCard)
        {
            hasKeyCard = true;
        }
        if (pickerItem == Items.OfficerWearing)
        {
            hasOfficerWear = true;
        }
        if (pickerItem == Items.Code)
        {
            hasCodeKey = true;
        }
        if (pickerItem == Items.Pistol)
        {
            hasPistol = true;
        }
        if (pickerItem == Items.StuffKey)
        {
            hasStuffKey = true;
        }
        Destroy(item.gameObject);
    }


}

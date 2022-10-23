using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCIdleConstructor : MonoBehaviour
{
    [SerializeField] private Transform[] arms;
    [SerializeField] private Transform[] shirts;
    [SerializeField] private Transform[] pants;
    [SerializeField] private Transform[] headVariations;
    [SerializeField] private Transform[] boots;
    [SerializeField] private Transform brows;

    private void Start()
    {
        ConstructNPC();
    }

    private void ConstructNPC()
    {
        int armIndex = ConstructArms();
        if (armIndex == 0) // long arms
        {
            shirts[0].gameObject.SetActive(true);
        }
        else if (armIndex == 1) // middle arms
        {
            shirts[3].gameObject.SetActive(true);
        }
        else if (armIndex == 2)
        {
            shirts[Random.Range(1, 3)].gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Invalid arm type! Should be: 0,1,2. Armtype: " + armIndex);
        }
        ConstructOtherParts();
    }

    private int ConstructArms()
    {
        int index = Random.Range(0, arms.Length);
        arms[index].gameObject.SetActive(true);
        return index;
    }

    private void ConstructOtherParts()
    {
        pants[Random.Range(0, pants.Length)].gameObject.SetActive(true);
        if (Random.Range(0, 2) == 1) // else skinhead
        {
            headVariations[Random.Range(0, headVariations.Length)].gameObject.SetActive(true);
        }
       
        if (Random.Range(0, 2) == 1)
        {
            brows.gameObject.SetActive(true);
        }
        boots[Random.Range(0, boots.Length)].gameObject.SetActive(true);
    }
}

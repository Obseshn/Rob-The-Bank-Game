using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WearingColorMaterialChanger : MonoBehaviour
{
    private void Start()
    {
        transform.GetComponent<SkinnedMeshRenderer>().material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }
}

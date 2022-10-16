using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballisticsLabDoorScript_gjm : MonoBehaviour
{


    Animator doorAnimation;

    // Start is called before the first frame update
    void Start()
    {
        doorAnimation = this.transform.parent.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        doorAnimation.SetBool("isOpening", true);
    }


    void OnTriggerExit(Collider other)
    {
        doorAnimation.SetBool("isOpening", false);
    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCamTriggers : MonoBehaviour
{
    public GameObject Cam1;
    public GameObject Cam2;
    public bool swap = false;
    //when entering this trigger the follow camera is turned off and an over head camera turned on
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        { 
            Cam1.gameObject.SetActive(false);
            Cam2.gameObject.SetActive(true);
            swap = true;
        }
    }
    //when leaving the trigger the follow camera turns on and the over head turns off
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Cam1.gameObject.SetActive(true);
            Cam2.gameObject.SetActive(false);
            swap = false;
        }
    }

}

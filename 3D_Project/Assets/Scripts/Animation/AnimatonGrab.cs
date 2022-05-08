using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatonGrab : MonoBehaviour
{
    [SerializeField] private Animator anGrab;
    
    
    private void OnTriggerEnter(Collider other)
    {
        //animation play for grabing materials
        if (other.gameObject.tag == "Player")
        {
            anGrab.SetBool("IsGrab", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //animation stop for grabing materials
        if (other.gameObject.tag == "Player")
        {
            anGrab.SetBool("IsGrab", false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamInteractTrigger : MonoBehaviour
{
    public GameObject Cam1GameObject;
   

    private Icam cam;

    private void Awake()
    {
        cam = Cam1GameObject.GetComponent<Icam>();
       
    }

    void OnTriggerEnter(Collider other)
    {
        cam.CamToggle();
    }

    void OnTriggerExit(Collider other)
    {
        cam.CamToggle();
    }

}

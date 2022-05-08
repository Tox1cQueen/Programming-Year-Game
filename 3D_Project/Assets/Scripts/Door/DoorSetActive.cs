using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSetActive : MonoBehaviour, IDoor
{
    private bool isOpen = false;

    //setting the door game object to disabled in the hierarchy
    public void OpenDoor()
    {
        isOpen = true;
        gameObject.SetActive(false);

    }
    //setting the door game object to not disabled in the hierarchy
    public void CloseDoor()
    {
        isOpen=false;
        gameObject.SetActive(true);


    }
    //to know what code to run  
    public void ToggleDoor()
    {
        isOpen = !isOpen;
        if (isOpen)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }

    }

}

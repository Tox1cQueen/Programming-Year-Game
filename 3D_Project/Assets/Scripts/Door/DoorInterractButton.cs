using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInterractButton : MonoBehaviour
{
    public GameObject doorGameObject;
    //public Transform playerTransform;

    private IDoor door;

    private void Awake()
    {
        door = doorGameObject.GetComponent<IDoor>();

    }
   
    //knows when an object with a colider entres the trigger zone
    void OnTriggerEnter(Collider other)
    {
        door.ToggleDoor();
    }

   
    //knows when an object with a colider leaves the trigger zone
    void OnTriggerExit(Collider other)
    {
        door.ToggleDoor();
    }

}

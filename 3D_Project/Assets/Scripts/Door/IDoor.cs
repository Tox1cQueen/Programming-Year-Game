using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//made an intorace to be able to store information and get between C# scripts 

public interface IDoor 
{
    void OpenDoor();
    void CloseDoor();
    void ToggleDoor();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallActive : MonoBehaviour, IWall
{
    private bool Phaseed = false;

    //set gmae object to disabled
    public void IsPhase()
    {
        Phaseed = true;
        gameObject.SetActive(false);
    }
   
    //sets game object to enabled
    public void IsSolid()
    {
        Phaseed = false;
        gameObject.SetActive(true);
    }

    //determine what code to run
    public void IsToggle()
    {
        Phaseed = !Phaseed;
        if (Phaseed)
        {
            IsPhase();
        }
        else
        {
            IsSolid();
        }
    }

}

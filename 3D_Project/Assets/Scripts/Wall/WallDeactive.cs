using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDeactive : MonoBehaviour, IWall
{
    private bool Phaseed = false;

    //enable game object
    public void IsPhase()
    {
        Phaseed = true;
        gameObject.SetActive(true);
    }

    //disable game object
    public void IsSolid()
    {
        Phaseed = false;
        gameObject.SetActive(false);
    }

    public void IsToggle()
    {
       //determine what code is ran
        if (Phaseed)
        {
            IsSolid();
        }
        else
        {
            IsPhase();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSetActive : MonoBehaviour, Icam
{
    private bool CamSwap = false;

    public void Cam2()
    {
        CamSwap = true;
        gameObject.SetActive(false);
    }

    public void Cam1()
    {
        CamSwap=false;
        gameObject.SetActive(true);
    }

    public void CamToggle()
    {
        CamSwap = !CamSwap;
        if (CamSwap)
        {
            Cam2();
        }else 
        {
            Cam1();
        }
            
    }
}

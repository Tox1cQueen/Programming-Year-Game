using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//made an interface to store and get information from different C# scripts
public interface IWall 
{
    void IsPhase();
    void IsSolid();
    void IsToggle();
}

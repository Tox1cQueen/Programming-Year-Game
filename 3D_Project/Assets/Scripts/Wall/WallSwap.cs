using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSwap : MonoBehaviour
{
    //getting access to a game object
    public GameObject wallGameObject;
    //getting access to the interface that was setup
    private IWall wall;

    private  void Awake()
    {
        wall = wallGameObject.GetComponent<IWall>();
    }


    private void Update()
    {
        //pressing Q will send a message to play code in a different script
        if (Input.GetKeyDown(KeyCode.Q))
        {
            wall.IsToggle();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleOneWallSwap : MonoBehaviour
{
    public GameObject Wall;
    //trigger to destroy wall
    void OnTriggerEnter(Collider other)
    {
        Wall.gameObject.SetActive(false);
    }
}

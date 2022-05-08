using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSpawn : MonoBehaviour
{
    public GameObject Spawn;
    public bool stopSpawning = false;
    public float SpawnTime;
    public float SpawnDelay;


    void Start()
    {
        //having it spawn a game object repetedly 
        InvokeRepeating("SpawnObject", SpawnTime, SpawnDelay);
    }

   public void SpawnObject()
    {
        //the function 
        Instantiate(Spawn, transform.position, transform.rotation);
        if (stopSpawning == true)
        {
            CancelInvoke("SpawnObject");
        }
    }
}

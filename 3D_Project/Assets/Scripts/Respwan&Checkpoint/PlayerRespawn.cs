using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform checkPoint;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
          player.transform .position = checkPoint.transform.position;
            Debug.Log("WORK");
        }
    }

    void update()
    {
        player.transform.position = checkPoint.transform.position;
    }

}

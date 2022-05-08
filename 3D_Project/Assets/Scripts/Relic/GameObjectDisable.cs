using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectDisable : MonoBehaviour
{
    public Money money;

    //trigger to make it look like u picked up the relic
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            Debug.Log("Hi everyone, I hope you all enjoyed the presentation and if not well to bad :)");
            money.materials += 1;
            money.money += money.gain;
        }

    }
}

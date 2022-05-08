using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SaveObject 
{
    public Money money;
    public Text shownMats;
    public Text shownMoney;

    public int playerMoney;
    public int playerMaterials;

    public float enemyPosX;
    public float enemyPosY;
    public float enemyPosZ;

    void Update()
    { 
        money.money += playerMoney;
     
        money.materials += playerMaterials;
    }
    void KeyPressed()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            shownMats.text = money.materials.ToString();
            shownMoney.text = money.money.ToString();
        }
    }
}

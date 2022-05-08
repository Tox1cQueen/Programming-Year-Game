using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Money : MonoBehaviour
{
    public int materials = 0;
    public int money = 0;
    public int gain;
    public Text shownMats;
    public Text shownMoney;
    public Text shownMatsP;
    public Text shownMoneyP;

    void Start()
    {
        materials = 0;
        money = 0;
    }

    void Update()
    {
        //getting a random value for when materials are pick up
        gain = Random.Range(200, 1000);
        //showing values on ui
        shownMats.text = materials.ToString();
        shownMoney.text = money.ToString();
        shownMatsP.text = materials.ToString();
        shownMoneyP.text = money.ToString();
    }
}
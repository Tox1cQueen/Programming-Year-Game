using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    public SaveObject so;

    public Money money;
    public Text shownMats;
    public Text shownMoney;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Manger.Save(so);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            so = Manger.Load();

          
            shownMats.text = money.materials.ToString();
            shownMoney.text = money.money.ToString();
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameHandler : MonoBehaviour
{
    public Money money;

    public Transform  ai;
    public Vector3 ai2;

    public Transform ball;
    public Vector3 ball2;

    // Update is called once per frame
    void Update()
    {
      PlayerData playerData = new PlayerData();
        playerData.Materials = money.money;
        playerData.Postion = ai2;
        playerData.White = ball2;
        string json = JsonUtility.ToJson(playerData);
       // Debug.Log(json);
        File.WriteAllText(Application.dataPath + "/saveFile.json", json);

        PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(json);
       // Debug.Log("materials" + loadedPlayerData.Materials);

        ai2 = ai.position;
        ball2 = ball.position;
    }

    private class PlayerData
    {
        public float Materials;

        public Vector3 Postion;

        public Vector3 White;
    }
    
}

   




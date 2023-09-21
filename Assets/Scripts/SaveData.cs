using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEditor;

public class SaveData : MonoBehaviour
{
    public int coins;
    public string rute;

    public int tier1;
    public int tier2;
    public int tier3;
    public int tier4;
    public int tier5;
    public int tier6;

    public int TD;
    public int TDC;

    SavePoints SaveP;
    public static GameManager gameManager;
    public static SaveData SaveDuck;

    public string Saverute;

    void Awake()
    {
        SaveDuck = this;
    }

    public void Load() 
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "DuckClusterData.json");

        if (File.Exists(filePath)) 
        {
            rute = Application.streamingAssetsPath + "/DuckClusterData.json";
            string json = System.IO.File.ReadAllText(rute);
            SaveP = JsonUtility.FromJson<SavePoints>(json);

            coins = (SaveP.coins);
            tier1 = (SaveP.tier1);
            tier2 = (SaveP.tier2) * 2;
            tier3 = (SaveP.tier3) * 4;
            tier4 = (SaveP.tier4) * 8;
            tier5 = (SaveP.tier5) * 16;
            tier6 = (SaveP.tier6) * 32; 

            TD = tier1 + tier2 + tier3 + tier4 + tier5 + tier6;

            for (int i = 0; i < TD; i++) 
            {
                TDC = 25 * (i + 1);
            }

            GameManager.gameManager.Add_Coins(coins + TDC);
        }
        else 
        {
            GameManager.gameManager.Add_Coins(600);
        }
    }

    public void Update()
    {
        Save();
    }


    public void Save() 
    {
        coins = GameManager.gameManager.coins;
        rute = Application.streamingAssetsPath + "/DuckClusterData.json";
        SaveP = new SavePoints(coins, tier1, tier2, tier3, tier4, tier5, tier6);
        string json = JsonUtility.ToJson(SaveP, true);
        print(json);
        System.IO.File.WriteAllText(rute, json);
    }
}

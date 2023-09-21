using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Upgrades : MonoBehaviour
    {
    public GameObject upgrades_Window;

    public  Button buyCrates_Button;
    void Start()
    {
        
    }

  
    void Update()
    {
        
    }


    public void OpenClose_Upgrades()
    {
      upgrades_Window.SetActive(!upgrades_Window.activeSelf);
    }

    public void Buy_Crates() 
    {
        if(GameManager.gameManager.coins >= 300) 
        {
            GameManager.gameManager.Add_Coins(-300);
            GameManager.gameManager.Start_Crate_Spawn();


            buyCrates_Button.interactable = false;
        }
    }
}

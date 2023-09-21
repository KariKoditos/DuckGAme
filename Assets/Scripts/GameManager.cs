using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public static GameManager gameManager;
    public static SaveData SaveDuck;

    public GameObject duck_Prefab, crate_Prefab;
    public GameObject newDuck_Window;
    public TextMeshProUGUI newDuck_Name;
    public Image newDuck_Image; 
    public SpriteRenderer Fence;

    public string[] duck_Names;
    public Sprite[] duck_Sprites,Egg_Sprites;

    public int coins, bought_Duck;
    public int highest_tier;
    public int totalDucks;

     void Awake()
    {
        gameManager = this;
    }

    private void Start()
    {
        Spawn_Duck();
        SaveData.SaveDuck.Load();
    }

    void Update()
    {

    }

    public void Buy_Duck()
    {
        if (coins >= 25 * (bought_Duck + 1)) 
       {
         Add_Coins(-25 * (bought_Duck + 1));
            bought_Duck++;
        Spawn_Duck();
            
       }
    }

    public void Spawn_Duck()
    {
        Vector3 position = new Vector3(Random.Range(Fence.bounds.extents.x -0.15f, (Fence.bounds.extents.x * -1) + 0.15f), Random.Range(Fence.bounds.extents.y -0.5f,(Fence.bounds.extents.y * -1) + 0.5f),0);
        Instantiate(duck_Prefab, position, Quaternion.identity,null);
    }

    public void Spawn_Duck_At(Vector3 position) 
     {
       
        Instantiate(duck_Prefab, position, Quaternion.identity, null);
    }

    public void Spawn_Crate() {
        Vector3 position = new Vector3(Random.Range(Fence.bounds.extents.x - 0.15f, (Fence.bounds.extents.x * -1) + 0.15f), Random.Range(Fence.bounds.extents.y - 0.5f, (Fence.bounds.extents.y * -1) + 0.5f), 0);
        Instantiate(crate_Prefab, position, Quaternion.identity, null);
    }

    public void Start_Crate_Spawn() 
    {
        InvokeRepeating("Spawn_Crate", 1, 5);
    }

    public void Check_Tier(int tier) 
    {
        if(tier > highest_tier) 
        {
            highest_tier = tier;

            StartCoroutine(New_Tier());
        }
    }
    public void Add_Coins(int amount)
    {
        coins += amount;

        Texts.texts.ChangeText_Coins(coins);
    }

    IEnumerator New_Tier() 
    {
        newDuck_Window.SetActive(true);
        newDuck_Name.text = duck_Names[highest_tier];
        newDuck_Image.sprite = duck_Sprites[highest_tier];

        yield return new WaitForSeconds(2);


        newDuck_Window.SetActive(false);
    }
}

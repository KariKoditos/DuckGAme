using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public int tier;
    void Start()
    {
        Set_Egg();
    }

    public void Set_Egg() 
    {
     GetComponent<SpriteRenderer>().sprite = GameManager.gameManager.Egg_Sprites[tier];
     StartCoroutine(Dissapear());
    }

    IEnumerator Dissapear () 
    {
        yield return new WaitForSeconds(1);

        GameManager.gameManager.Add_Coins((int)Mathf.Pow(10, tier));

        Destroy(gameObject);
    }
    
}

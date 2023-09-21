using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Duck : MonoBehaviour
{

    
    public static GameManager gameManager;
    public int tier, good_Egg, bad_Egg;
    bool isDragged, hasDestination;

    Vector3 destination, offset;

    public Egg egg;


    float Egg_Frequency, Egg_InBelly;

    public static SaveData SaveDuck;

    void Start()
    {
        Set_Duck();
        InvokeRepeating("Take_Egg", 1, 3);
    }

    void Update()
    {
        Egg_InBelly += Egg_Frequency * bad_Egg;

        if (!isDragged)
        {
            if (hasDestination)
            {
                if (Vector3.Distance(transform.position, destination) > .5f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, destination, 1 * Time.deltaTime);
                }
                else
                {
                    hasDestination = false;
                }
            }
            else
            {
                destination = new Vector3(Random.Range(GameManager.gameManager.Fence.bounds.extents.x -0.15f, (GameManager.gameManager.Fence.bounds.extents.x * -1) + 0.15f), Random.Range(GameManager.gameManager.Fence.bounds.extents.y -0.5f, (GameManager.gameManager.Fence.bounds.extents.y * -1) + 0.5f),0);
                hasDestination = true;
            }
        }
    }

public void Set_Duck()
{
    GetComponent<SpriteRenderer>().sprite = GameManager.gameManager.duck_Sprites[tier];

    bad_Egg = tier / 5;

    if (tier != 0)
    {
        good_Egg = bad_Egg + 1;
    }
    else
    {
        good_Egg = bad_Egg;
    }

    Egg_Frequency = (tier + 1) * 0.5f;

    if (tier == 0)
    {
        SaveData.SaveDuck.tier1 ++;
    }
    else if (tier == 1)
    {
        SaveData.SaveDuck.tier2 ++;
    }
    else if (tier == 2)
    {
        SaveData.SaveDuck.tier3 ++;
    }
    else if (tier == 3)
    {
        SaveData.SaveDuck.tier4 ++;
    }
    else if (tier == 4)
    {
        SaveData.SaveDuck.tier5 ++;
    }
    else if (tier == 5)
    {
        SaveData.SaveDuck.tier6 ++;
    }
}

    public void Evolve()
    {
        tier++;
        GameManager.gameManager.Check_Tier(tier);
        Set_Duck();
    }

    public void Take_Egg()
    {
        Egg new_Egg = Instantiate(egg, transform.position, Quaternion.identity, null);

        if (Egg_InBelly >= Mathf.Pow(10, good_Egg)) 
       {
            new_Egg.tier = good_Egg;
            Egg_InBelly -= Mathf.Pow(10, good_Egg);
       }

       else 
       {
            new_Egg.tier = bad_Egg;
            Egg_InBelly -= Mathf.Pow(10, bad_Egg);

       }
    }

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
    }

    private void OnMouseDrag()
    {
        isDragged = true;

        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)) + offset;

    }

    private void OnMouseUp()
    {
        isDragged = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDragged)
        {
            if (collision.tag == "Duck")
            {
                if (collision.GetComponent<Duck>().tier == tier)
                {
                    Evolve();

                    Destroy(collision.gameObject);

                    if (tier == 0)
                    {
                        SaveData.SaveDuck.tier1++;
                    }
                    else if (tier == 1)
                    {
                        SaveData.SaveDuck.tier2++;
                    }
                    else if (tier == 2)
                    {
                        SaveData.SaveDuck.tier3++;
                    }
                    else if (tier == 3)
                    {
                        SaveData.SaveDuck.tier4++;
                    }
                    else if (tier == 4)
                    {
                        SaveData.SaveDuck.tier5++;
                    }
                    else if (tier == 5)
                    {
                        SaveData.SaveDuck.tier6++;
                    }
                }
            }
        }
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isDragged)
        {
            if (collision.tag == "Duck")
            {
                if (collision.GetComponent<Duck>().tier == tier)
                {
                    Evolve();

                    Destroy(collision.gameObject);

                    if (tier == 0)
                    {
                        SaveData.SaveDuck.tier1++;
                    }
                    else if (tier == 1)
                    {
                        SaveData.SaveDuck.tier2++;
                    }
                    else if (tier == 2)
                    {
                        SaveData.SaveDuck.tier3++;
                    }
                    else if (tier == 3)
                    {
                        SaveData.SaveDuck.tier4++;
                    }
                    else if (tier == 4)
                    {
                        SaveData.SaveDuck.tier5++;
                    }
                    else if (tier == 5)
                    {
                        SaveData.SaveDuck.tier6++;
                    }
                }
            }
        }
    }
}

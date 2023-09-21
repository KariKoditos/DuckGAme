using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Texts : MonoBehaviour
{

    public static Texts texts;

    public TextMeshProUGUI coins_Text;
    // Start is called before the first frame update
    void Awake()
    {
        texts = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeText_Coins(int amount)
    {
        coins_Text .text = amount.ToString();
    }
}

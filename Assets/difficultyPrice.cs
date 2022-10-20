using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class difficultyPrice : MonoBehaviour
{
    private Text priceText, priceTextShadow;
    // Start is called before the first frame update
    void Start()
    {
        priceText = gameObject.GetComponent<Text>();
        priceTextShadow = GameObject.Find("Text (3)").GetComponent<Text>();
        int price = int.Parse(gameObject.GetComponent<Text>().text);

        int difficulty = PlayerPrefs.GetInt("difficulty", 0);
        switch(difficulty){
            case 0:
                break;
            case 1:
                price -= 700;
                break;
            case 2:
                price -= 1000;
                break;
            default:
                break;
        }

        priceText.text = price.ToString();
        priceText.SetAllDirty();
        priceTextShadow.text = price.ToString();
        priceTextShadow.SetAllDirty();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

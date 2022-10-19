using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarCount : MonoBehaviour
{
    public bool Eighteen;
    // Start is called before the first frame update
    void Start()
    {
        string[] levelNames = {"LetoHighScore", "2amHighScore", "VozisHighScore","IzvanHighScore", "BeboPaziHighScore","ZenaHighScore", "PoslednjaNocHighScore"};

        int difficulty = PlayerPrefs.GetInt("difficulty", 0);
        string postfix = "Stars";
        switch(difficulty){
            case 0:
                break;
            case 1:
                postfix = "MediumStars";
                break;
            case 2:
                postfix = "HardStars";
                break;
            default:
                break;
        }

        for(int i = 0; i < levelNames.Length; i++){
            levelNames[i] += postfix;
        }

        for(int i = 0; i < levelNames.Length; i++){
            if(!PlayerPrefs.HasKey(levelNames[i]))
                PlayerPrefs.SetInt(levelNames[i],0);
        }

        /*
        if(!PlayerPrefs.HasKey("LetoHighScoreStars"))
            PlayerPrefs.SetInt("LetoHighScoreStars",0);
        if(!PlayerPrefs.HasKey("2amHighScoreStars"))
            PlayerPrefs.SetInt("2amHighScoreStars",0);        
        if(!PlayerPrefs.HasKey("VozisHighScoreStars"))
            PlayerPrefs.SetInt("VozisHighScoreStars",0);
        if(!PlayerPrefs.HasKey("IzvanHighScoreStars"))
            PlayerPrefs.SetInt("IzvanHighScoreStars",0);            
        if(!PlayerPrefs.HasKey("BeboPaziHighScoreStars"))
            PlayerPrefs.SetInt("BeboPaziHighScoreStars",0);
        if(!PlayerPrefs.HasKey("ZenaHighScoreStars"))
            PlayerPrefs.SetInt("ZenaHighScoreStars",0);
        if(!PlayerPrefs.HasKey("PoslednjaNocHighScoreStars"))
            PlayerPrefs.SetInt("PoslednjaNocHighScoreStars",0);
        */
        
        int count=0;
        for(int i = 0; i < levelNames.Length; i++){
            count += PlayerPrefs.GetInt(levelNames[i]);
        }

        /*
        count = PlayerPrefs.GetInt("LetoHighScoreStars") +
                PlayerPrefs.GetInt("2amHighScoreStars") +
                PlayerPrefs.GetInt("VozisHighScoreStars") +
                PlayerPrefs.GetInt("IzvanHighScoreStars") +
                PlayerPrefs.GetInt("BeboPaziHighScoreStars") +
                PlayerPrefs.GetInt("ZenaHighScoreStars") +
                PlayerPrefs.GetInt("PoslednjaNocHighScoreStars");
        */
        gameObject.GetComponent<Text>().text=count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }
}

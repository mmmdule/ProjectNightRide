using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainStatsScript : MonoBehaviour
{
    /*
        •Osvojene zvezdice - 
        •Sakpuljenih para - 
        •Najigraniji nivo - 
        •Broj perfektnih - 
        •GameOver - 
        •Nastavaljeno nakon GameOver - 
    */

    string GetStars(){
        string result = "";
        
        string[] levelNames = {"LetoHighScore", "2amHighScore", "VozisHighScore","IzvanHighScore", "BeboPaziHighScore","ZenaHighScore", "PoslednjaNocHighScore"};

        string[] levelNamesTmp = new string[levelNames.Length];
        levelNames.CopyTo(levelNamesTmp, 0);

        string[] postfix = {"Stars", "MediumStars", "HardStars"};

        double count=0.00;
        for (int j = 0; j < postfix.Length; j++){
            levelNames.CopyTo(levelNamesTmp, 0);
            for (int i = 0; i < levelNames.Length; i++){
                levelNamesTmp[i] += postfix[j];
            }
            for (int i = 0; i < levelNames.Length; i++){
                if (!PlayerPrefs.HasKey(levelNamesTmp[i]))
                    PlayerPrefs.SetInt(levelNamesTmp[i], 0);
                count += PlayerPrefs.GetInt(levelNamesTmp[i],0);
            }
        }
        double percent = (count/63.00);
        result = count + "/63 (" + percent.ToString("P2") +")"; //P2 je format za procenat sa 2 decimale

        //Debug.Log("Count = " + count);
        //Debug.Log("Percent = " + percent);
        
        return result;
    }

    string CollectedCoins(){
        string result = PlayerPrefs.GetInt("CollectedCoins",0).ToString();
        return result;
    }

    string PerfectRuns(){
        string result = PlayerPrefs.GetInt("PerfectRuns",0).ToString();
        return result;
    }
    string GameOvers(){
        string result = PlayerPrefs.GetInt("GameOvers",0).ToString();
        return result;
    }

    string Continues(){
        string result = PlayerPrefs.GetInt("Continues",0).ToString();
        return result;
    }

    string MostPlayed(){
        string result = "";
        return result;
    }

    // Start is called before the first frame update
    void Start()
    {
        string[] stats = gameObject.GetComponent<Text>().text.Split('\n');
        stats[0] += GetStars();
        stats[1] += CollectedCoins();
        stats[2] += MostPlayed();
        stats[3] += PerfectRuns();
        stats[4] += GameOvers();
        stats[5] += Continues();

        gameObject.GetComponent<Text>().text = "";
        foreach(string s in stats)
            gameObject.GetComponent<Text>().text += s + "\n";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

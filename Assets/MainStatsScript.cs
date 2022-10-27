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

    string MostPlayed(){ //Mozda moze i da proveri koja je tezina
        string[] LevelPrefNames = {"Leto", "2am", "Vozis", "Izvan", "BeboPazi", "Zena", "PoslednjaNoc"};
        string[] LevelNames = {"Leto", "2am", "Luna", "Izvan vremena", "Bebo, pazi", "Zena", "Poslednja Noc"};

        int[] LevelValues = { 
            PlayerPrefs.GetInt("LetoLevelCount",0) + PlayerPrefs.GetInt("LetoMediumLevelCount",0) + PlayerPrefs.GetInt("LetoHardLevelCount",0),
            PlayerPrefs.GetInt("2amLevelCount",0) + PlayerPrefs.GetInt("2amMediumLevelCount",0) + PlayerPrefs.GetInt("2amHardLevelCount",0),  
            PlayerPrefs.GetInt("VozisLevelCount",0) + PlayerPrefs.GetInt("VozisMediumLevelCount",0) + PlayerPrefs.GetInt("VozisHardLevelCount",0),
            PlayerPrefs.GetInt("IzvanLevelCount",0) + PlayerPrefs.GetInt("IzvanMediumLevelCount",0) + PlayerPrefs.GetInt("IzvanHardLevelCount",0),
            PlayerPrefs.GetInt("BeboPaziLevelCount",0) + PlayerPrefs.GetInt("BeboPaziMediumLevelCount",0) + PlayerPrefs.GetInt("BeboPaziHardLevelCount",0),
            PlayerPrefs.GetInt("ZenaLevelCount",0) + PlayerPrefs.GetInt("ZenaMediumLevelCount",0) + PlayerPrefs.GetInt("ZenaHardLevelCount",0),
            PlayerPrefs.GetInt("PoslednjaNocLevelCount",0) + PlayerPrefs.GetInt("PoslednjaNocMediumLevelCount",0) + PlayerPrefs.GetInt("PoslednjaNocHardLevelCount",0)
        };

        List<KeyValuePair<int, string>> LevelKeyValuePairList = new List<KeyValuePair<int, string>>();
        for(int i = 0; i < LevelValues.Length; i++)
            LevelKeyValuePairList.Add( new KeyValuePair<int, string>(LevelValues[i], LevelNames[i]) );
        /*
        LevelKeyValuePairList.Add(new KeyValuePair<int, string>(PlayerPrefs.GetInt("LetoLevelCount",0) + PlayerPrefs.GetInt("LetoMediumLevelCount",0) + PlayerPrefs.GetInt("LetoHardLevelCount",0), LevelNames[0]));
        LevelKeyValuePairList.Add(new KeyValuePair<int, string>(PlayerPrefs.GetInt("2amLevelCount",0) + PlayerPrefs.GetInt("2amMediumLevelCount",0) + PlayerPrefs.GetInt("2amHardLevelCount",0), LevelNames[1]));
        LevelKeyValuePairList.Add(new KeyValuePair<int, string>(PlayerPrefs.GetInt("VozisLevelCount",0) + PlayerPrefs.GetInt("VozisMediumLevelCount",0) + PlayerPrefs.GetInt("VozisHardLevelCount",0), LevelNames[2]));
        LevelKeyValuePairList.Add(new KeyValuePair<int, string>(PlayerPrefs.GetInt("IzvanLevelCount",0) + PlayerPrefs.GetInt("IzvanMediumLevelCount",0) + PlayerPrefs.GetInt("IzvanHardLevelCount",0), LevelNames[3]));
        LevelKeyValuePairList.Add(new KeyValuePair<int, string>(PlayerPrefs.GetInt("BeboPaziLevelCount",0) + PlayerPrefs.GetInt("BeboPaziMediumLevelCount",0) + PlayerPrefs.GetInt("BeboPaziHardLevelCount",0), LevelNames[4]));
        LevelKeyValuePairList.Add(new KeyValuePair<int, string>(PlayerPrefs.GetInt("ZenaLevelCount",0) + PlayerPrefs.GetInt("ZenaMediumLevelCount",0) + PlayerPrefs.GetInt("ZenaHardLevelCount",0), LevelNames[4]));
        LevelKeyValuePairList.Add(new KeyValuePair<int, string>(PlayerPrefs.GetInt("PoslednjaNocLevelCount",0) + PlayerPrefs.GetInt("PoslednjaNocMediumLevelCount",0) + PlayerPrefs.GetInt("PoslednjaNocHardLevelCount",0), LevelNames[5]));
        */

        LevelKeyValuePairList.Sort((x, y) => x.Key.CompareTo(y.Key));


        string result = LevelKeyValuePairList[LevelKeyValuePairList.Count-1].Value;
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

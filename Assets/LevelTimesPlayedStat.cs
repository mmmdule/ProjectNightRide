using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimesPlayedStat : MonoBehaviour
{
    public string LevelName;
    public int Value;
    // Start is called before the first frame update
    void Start()
    {
        if(changeTimesPlayedCount(LevelName, Value)==0)
            Debug.Log("Times level has been played Stat successfully saved.");
    }

    int changeTimesPlayedCount(string LevelName, int value){ //value = 1 for increase, -1 for decrease
        try{
            int difficulty = PlayerPrefs.GetInt("difficulty", 0);
            switch(difficulty){
                case 0:
                    break;
                case 1:
                    LevelName += "Medium";
                    break;
                case 2:
                    LevelName += "Hard";
                    break;
                default:
                    break;
            }
            LevelName += "LevelCount";

            int count = PlayerPrefs.GetInt(LevelName, 0) + value;
            PlayerPrefs.SetInt(LevelName, count);
            PlayerPrefs.Save(); //exclude if performance is impacted

            return 0;
        }
        catch{
            return -1;
        }
        
    }

}

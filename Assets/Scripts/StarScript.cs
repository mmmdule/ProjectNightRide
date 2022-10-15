using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    public string LevelName;
    public int limit;
    public bool one,two,three;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        if(LevelName=="PoslednjaNocHighScore"){
            if(PlayerPrefs.GetInt(LevelName)>=limit){
                gameObject.GetComponent<SpriteRenderer>().color=new Color32(255, 162, 0, 255);
                if(!PlayerPrefs.HasKey(LevelName))
                    PlayerPrefs.SetInt(LevelName,0);
                PlayerPrefs.SetInt(LevelName + "Stars",0);
                if(one)
                    PlayerPrefs.SetInt(LevelName + "Stars", PlayerPrefs.GetInt(LevelName + "Stars") + 1);
                else if (two)
                    PlayerPrefs.SetInt(LevelName + "Stars", PlayerPrefs.GetInt(LevelName + "Stars") + 2);
                else if (three)            
                    PlayerPrefs.SetInt(LevelName + "Stars", PlayerPrefs.GetInt(LevelName + "Stars") + 3);
            }
        }
        else 
            if(PlayerPrefs.GetInt(LevelName)>=limit){
                gameObject.GetComponent<SpriteRenderer>().color=Color.yellow;
                if(!PlayerPrefs.HasKey(LevelName))
                    PlayerPrefs.SetInt(LevelName,0);
                PlayerPrefs.SetInt(LevelName + "Stars",0);
                if(one)
                    PlayerPrefs.SetInt(LevelName + "Stars", PlayerPrefs.GetInt(LevelName + "Stars") + 1);
                else if (two)
                    PlayerPrefs.SetInt(LevelName + "Stars", PlayerPrefs.GetInt(LevelName + "Stars") + 2);
                else if (three)            
                    PlayerPrefs.SetInt(LevelName + "Stars", PlayerPrefs.GetInt(LevelName + "Stars") + 3);
            } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

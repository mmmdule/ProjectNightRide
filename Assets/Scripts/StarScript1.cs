using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript1 : MonoBehaviour
{
    public string LevelName;
    public int limit;
    public bool one,two,three;
    public bool isMainMenu;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        Color starColor = Color.yellow;
        if(LevelName=="PoslednjaNocHighScore"){
                starColor = new Color32(255, 162, 0, 255);
        }

        

        //Commented out because color can start out as yellow so it's unnecessary to do this check
        /*else 
            if(PlayerPrefs.GetInt(LevelName)>=limit){
                starColor = Color.yellow;
            } 
        */ //Commented out because color can start out as yellow so it's unnecessary to do this check
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

        if(!PlayerPrefs.HasKey(LevelName))
                PlayerPrefs.SetInt(LevelName,0);

        if(PlayerPrefs.GetInt(LevelName)>=limit){
            Debug.Log(LevelName + " = " + PlayerPrefs.GetInt(LevelName));

            if(!isMainMenu)    
                gameObject.GetComponent<SpriteRenderer>().color = starColor;
            
            if(two)
                PlayerPrefs.SetInt(LevelName + "Stars", 2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

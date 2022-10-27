using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreStats : MonoBehaviour
{
    private List<int> scoresEasy;
    private List<int> scoresMedium;
    private List<int> scoresHard;

    private string[] defaultText;
    private Text[] ScoreText;
    private Text[] ButtonText;

    private int clickCount;

    // Start is called before the first frame update
    void Start()
    {
        ButtonText = new Text[2];
        ButtonText[0] = GameObject.Find("ScoreButtonText").GetComponent<Text>();
        ButtonText[1] = GameObject.Find("ScoreButtonTextShadow").GetComponent<Text>();

        ScoreText = new Text[2];
        ScoreText[0] = GameObject.Find("MainStatsText").GetComponent<Text>();
        ScoreText[1] = GameObject.Find("MainStatsTextShadow").GetComponent<Text>();

        defaultText = new string[]{"•Leto		    -      ", "•2am		    -      ", "•Luna		    -      ", "•Izvan vremena	-      ", "•Bebo, pazi	    -      ", "•Zena		    -      ", "•Poslednja noc	-      "};
        
        scoresEasy = new List<int>();
        scoresMedium = new List<int>();
        scoresHard = new List<int>();
        
        scoresEasy.Add(PlayerPrefs.GetInt("LetoHighScore",0));
        scoresMedium.Add(PlayerPrefs.GetInt("LetoHighScoreMedium",0)); 
        scoresHard.Add(PlayerPrefs.GetInt("LetoHighScoreHard",0)); 

        scoresEasy.Add(PlayerPrefs.GetInt("2amHighScore",0));
        scoresMedium.Add(PlayerPrefs.GetInt("2amHighScoreMedium",0)); 
        scoresHard.Add(PlayerPrefs.GetInt("2amHighScoreHard",0)); 

        scoresEasy.Add(PlayerPrefs.GetInt("VozisHighScore",0));
        scoresMedium.Add(PlayerPrefs.GetInt("VozisHighScoreMedium",0)); 
        scoresHard.Add(PlayerPrefs.GetInt("VozisHighScoreHard",0)); 

        scoresEasy.Add(PlayerPrefs.GetInt("IzvanHighScore",0));
        scoresMedium.Add(PlayerPrefs.GetInt("IzvanHighScoreMedium",0)); 
        scoresHard.Add(PlayerPrefs.GetInt("IzvanHighScoreHard",0)); 


        scoresEasy.Add(PlayerPrefs.GetInt("BeboPaziHighScore",0));
        scoresMedium.Add(PlayerPrefs.GetInt("BeboPaziHighScoreMedium",0)); 
        scoresHard.Add(PlayerPrefs.GetInt("BeboPaziHighScoreHard",0)); 

        scoresEasy.Add(PlayerPrefs.GetInt("ZenaHighScore",0));
        scoresMedium.Add(PlayerPrefs.GetInt("ZenaHighScoreMedium",0)); 
        scoresHard.Add(PlayerPrefs.GetInt("ZenaHighScoreHard",0)); 

        scoresEasy.Add(PlayerPrefs.GetInt("PoslednjaNocHighScore",0));
        scoresMedium.Add(PlayerPrefs.GetInt("PoslednjaNocHighScoreMedium",0)); 
        scoresHard.Add(PlayerPrefs.GetInt("PoslednjaNocHighScoreHard",0)); 
        
        

        clickCount = 0; //(1 - Easy, 2 - Medium, 3 - Hard)
        Klik();
    }

    public void Klik(){
        clickCount++;

        ScoreText[0].text = "";
        ScoreText[1].text = "";

        switch(clickCount){
            case 1:
                ButtonText[0].text = "Lako";
                ButtonText[1].text = "Lako";

                for(int i = 0; i < scoresEasy.Count; i++)
                    ScoreText[0].text += defaultText[i] + scoresEasy[i].ToString() + "\n";
                ScoreText[1].text = ScoreText[0].text;

                break;
            case 2:
                ButtonText[0].text = "Srednje";
                ButtonText[1].text = "Srednje";

                for(int i = 0; i < scoresEasy.Count; i++)
                    ScoreText[0].text += defaultText[i] + scoresMedium[i].ToString() + "\n";
                ScoreText[1].text = ScoreText[0].text;

                break;
            case 3:
                clickCount = 0;
                ButtonText[0].text = "Tesko";
                ButtonText[1].text = "Tesko";

                for(int i = 0; i < scoresEasy.Count; i++)
                    ScoreText[0].text += defaultText[i] + scoresHard[i].ToString() + "\n";
                ScoreText[1].text = ScoreText[0].text;

                break;
            default:
                break;
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyScript : MonoBehaviour
{
    public enum difficulty {easy, medium, hard};
    public int difficultyValue;
    private Button[] difficultyButtons;

    //Moze bez enum-a ako se ne upotrebi negde

    // Start is called before the first frame update
    void Start()
    {
        difficultyButtons = new Button[3];
        difficultyButtons[0] = GameObject.Find("EasyButton").GetComponent<Button>();
        difficultyButtons[1] = GameObject.Find("MediumButton").GetComponent<Button>();
        difficultyButtons[2] = GameObject.Find("HardButton").GetComponent<Button>();

        int difficultyInt = PlayerPrefs.GetInt("difficulty", 1);

        SetDifficulty(difficultyInt);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDifficulty(int diff){
        difficulty selectedDifficulty = (difficulty)diff;
        ColorBlock cb;
        foreach(Button button in difficultyButtons)
        {
            cb = button.colors;
		    cb.normalColor = Color.red;
		    button.colors = cb;
        }

        
        PlayerPrefs.SetInt("difficulty" , diff);
        PlayerPrefs.Save();
        
        cb = difficultyButtons[(int)selectedDifficulty].colors;
        cb.normalColor = Color.green;
        difficultyButtons[(int)selectedDifficulty].colors = cb;



        /*switch(selectedDifficulty){
            case difficulty.easy:
                break;
            case difficulty.medium:
                break;
            case difficulty.hard:
                break;
            default:
                break;
        }*/
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unlock : MonoBehaviour
{
    public GameObject button;
    public string LevelName;
    // Start is called before the first frame update
    void Start()
    {
        int difficulty = PlayerPrefs.GetInt("difficulty", 0);
        switch(difficulty){
            case 0:
                break;
            case 1:
                LevelName += "MediumStars";
                break;
            case 2:
                LevelName += "HardStars";
                break;
            default:
                break;
        }

        if (PlayerPrefs.GetInt(LevelName, 0)>0){
            button.GetComponent<Button>().enabled = true;
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStarCount : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("LetoHighScoreStars",0);
        PlayerPrefs.SetInt("2amHighScoreStars",0);   
        PlayerPrefs.SetInt("VozisHighScoreStars",0);
        PlayerPrefs.SetInt("IzvanHighScoreStars",0);
        PlayerPrefs.SetInt("BeboPaziHighScoreStars",0);
        PlayerPrefs.SetInt("ZenaHighScoreStars",0);
        PlayerPrefs.SetInt("PoslednjaNocHighScoreStars",0);        
        PlayerPrefs.SetInt("MaratonHighScoreStars",0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteScoresScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("f9"))
            PlayerPrefs.DeleteAll();
        else if(Input.GetKeyDown("f5")){
            PlayerPrefs.SetInt("LetoHighScore" , 12000);
            PlayerPrefs.SetInt("2amHighScore" , 12000);
            PlayerPrefs.SetInt("VozisHighScore" , 12000); //Luna je pre bila "Ti Me Vozis"
            PlayerPrefs.SetInt("IzvanHighScore" , 12000);
            PlayerPrefs.SetInt("BeboPaziHighScore" , 12000);
            PlayerPrefs.SetInt("ZenaHighScore" , 12000);
            //PlayerPrefs.SetInt("PoslednjaNocHighScore" , 12000);
        }
            
        
    }

    
}

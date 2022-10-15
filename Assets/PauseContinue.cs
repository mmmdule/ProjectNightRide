using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseContinue : MonoBehaviour
{   private GameObject player,Camera,pause, ButtonCanvas, countdownCanvas;
    public float spid,spidNPC;
    private GameObject endLevel;

    public void Klik()
    {        
        endLevel = GameObject.Find("EndOfLevelTrigger");
        pause = GameObject.Find("PauseCanvas");
        player = GameObject.Find("player");
        Camera = GameObject.Find("Main Camera");
        ButtonCanvas=GameObject.Find("ButtonCanvas");
        countdownCanvas=GameObject.Find("countdownCanvas");
        
        //Camera.GetComponent<AudioSource>().UnPause(); //Premesteno u pauseCountodwn.cs
        //Camera.GetComponent<CameraScript>().coinObstacleSpeed = spidNPC; //Premesteno u pauseCountodwn.cs

        pause.GetComponent<PlayerPause>().count++;
        pause.GetComponent<Canvas>().enabled=false;
        countdownCanvas.GetComponent<Canvas>().enabled = true;
        countdownCanvas.GetComponent<pauseCountdown>().enabled = true;
        countdownCanvas.GetComponent<pauseCountdown>().count = true;
        endLevel.GetComponent<EndOfLevel>().isPaused = false;

        //HERE
        //ButtonCanvas.SetActive(true);
        
        //HERE



        /*pause = GameObject.Find("PauseCanvas");
        player = GameObject.Find("player");
        Camera = GameObject.Find("Main Camera");
        
        
        */
        
        //Camera.GetComponent<CameraScript>().coinObstacleSpeed = spidNPC;
        
        /*pause.GetComponent<PlayerPause>().count++;
        pause.GetComponent<Canvas>().enabled=false;*/
    }

    /*public GameObject player,Camera,pause, ButtonCanvas;
    public float spid,spidNPC;

    public void Klik()
    {
        ButtonCanvas=GameObject.Find("ButtonCanvas");
        ButtonCanvas.SetActive(true);

        pause = GameObject.Find("PauseCanvas");
        player = GameObject.Find("player");
        Camera = GameObject.Find("Main Camera");
        
        player.GetComponent<PlayerMovement>().enabled=true;                        
        player.GetComponent<PlayerMovement>().speed=player.GetComponent<PlayerMovement>().speedOG;  

        Camera.GetComponent<CameraScript>().coinObstacleSpeed = spidNPC;
        Camera.GetComponent<AudioSource>().UnPause();
        
        pause.GetComponent<PlayerPause>().count++;
        pause.GetComponent<Canvas>().enabled=false;
    }*/
}

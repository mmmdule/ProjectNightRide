using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{   private GameObject pauseCanvas, ButtonCanvas;
    private GameObject Camera,Player,gameOver, frontWheel,backWheel;
    public float spid,spidNPC;
    private Canvas GameOverCanvas;
    private GameObject endLevel;
    

    public void KlikPause()
    {
        endLevel = GameObject.Find("EndOfLevelTrigger");
        pauseCanvas=GameObject.FindGameObjectWithTag("Pause");
        Camera = GameObject.Find("Main Camera");
        Player = GameObject.Find("player");
        frontWheel = GameObject.Find("frontWheel");
        backWheel = GameObject.Find("backWheel");

        spid = Player.GetComponent<PlayerMovement>().speed;
        spidNPC = Camera.GetComponent<CameraScript>().coinObstacleSpeed;
        Debug.Log("Spid = " + spid.ToString());

        pauseCanvas.GetComponent<Canvas>().enabled=true;
        pauseCanvas.GetComponent<PlayerPause>().count++;

        Player.GetComponent<PlayerMovement>().speed=0f;
        Player.GetComponent<PlayerMovement>().enabled=false;
        backWheel.GetComponent<WheelSpinFica>().enabled = false;
        frontWheel.GetComponent<WheelSpinFica>().enabled = false;
        if(Player.GetComponent<PlayerCrash>().invinci)
            Player.GetComponent<PlayerCrash>().pause=true;
        
        Camera.GetComponent<CameraScript>().coinObstacleSpeed=0f;
        Camera.GetComponent<AudioSource>().Pause();   

        ButtonCanvas=GameObject.Find("ButtonCanvas");
        ButtonCanvas.GetComponent<Canvas>().enabled=false;
        endLevel.GetComponent<EndOfLevel>().isPaused = true;
        //ButtonCanvas.SetActive(false);

        /*GameOverCanvas = GameObject.Find("GameOverCanvas").GetComponent<Canvas>();
        if(GameOverCanvas.enabled==false){
            pauseCanvas.GetComponent<Canvas>().enabled=true;
            Player.GetComponent<PlayerMovement>().speed=0f;
            Player.GetComponent<PlayerMovement>().enabled=false;
            Camera.GetComponent<CameraScript>().coinObstacleSpeed=0f;
            Camera.GetComponent<AudioSource>().Pause();
        }*/
        
        /*
                else{
                    pauseCanvas.GetComponent<Canvas>().enabled=false;                
                    Player.GetComponent<PlayerMovement>().speed=spid;
                    Player.GetComponent<PlayerMovement>().enabled=true;                
                    Camera.GetComponent<CameraScript>().coinObstacleSpeed=spidNPC;
                    Camera.GetComponent<AudioSource>().UnPause();
                }*/
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseCountdown : MonoBehaviour{
    private GameObject Camera,pause,player,ButtonCanvas,frontWheel,backWheel;
    private Text textMid,textFront,textBack;
    public bool count,gameOver;
    private int frames;
    private GameObject endLevel;
    // Start is called before the first frame update
    void Start(){
        endLevel = GameObject.Find("EndOfLevelTrigger");
        textBack = GameObject.Find("CountBackLayer").GetComponent<Text>();
        textMid = GameObject.Find("CountMiddleLayer").GetComponent<Text>();
        textFront = GameObject.Find("CountFrontLayer").GetComponent<Text>();

        count = false;
        gameOver = false;
        frames = 0;

        ButtonCanvas = GameObject.Find("ButtonCanvas");
        Camera = GameObject.Find("Main Camera");
        pause = GameObject.Find("PauseCanvas");
        player = GameObject.Find("player");
        frontWheel = GameObject.Find("frontWheel");
        backWheel = GameObject.Find("backWheel");
    }

    // Update is called once per frame
    void Update(){
        if(count){
            endLevel.GetComponent<EndOfLevel>().isPaused = true;
            if(frames==120){
                textBack.text = textBack.text.Replace(textBack.text, "2");
                textBack.SetAllDirty();
                textMid.text = textMid.text.Replace(textMid.text, "2");
                textMid.SetAllDirty();
                textFront.text = textFront.text.Replace(textFront.text, "2");
                textFront.SetAllDirty();
            }
            else if(frames==240){                
                textBack.text = textBack.text.Replace(textBack.text, "1");
                textBack.SetAllDirty();
                textMid.text = textMid.text.Replace(textMid.text, "1");
                textMid.SetAllDirty();
                textFront.text = textFront.text.Replace(textFront.text, "1");
                textFront.SetAllDirty();
            }
            else if(frames==360){      
                gameObject.GetComponent<Canvas>().enabled=false;

                textBack.text = textBack.text.Replace(textBack.text, "3");
                textBack.SetAllDirty();
                textMid.text = textMid.text.Replace(textMid.text, "3");
                textMid.SetAllDirty();
                textFront.text = textFront.text.Replace(textFront.text, "3");
                textFront.SetAllDirty();

                count = false;

                Camera.GetComponent<AudioSource>().UnPause();
                endLevel.GetComponent<EndOfLevel>().isPaused = false;
                endLevel.GetComponent<EndOfLevel>().isGameOver = false;

                Camera.GetComponent<CameraScript>().coinObstacleSpeed = player.GetComponent<PauseContinue>().spidNPC;
        
                player.GetComponent<PlayerMovement>().enabled=true;                        
                player.GetComponent<PlayerMovement>().speed=player.GetComponent<PlayerMovement>().speedOG;
                player.GetComponent<PlayerCrash>().pause = false;
                
                ButtonCanvas.GetComponent<Canvas>().enabled=true;
                frames = 0;

                backWheel.GetComponent<WheelSpinFica>().enabled = true;
                frontWheel.GetComponent<WheelSpinFica>().enabled = true;
                //gameObject.GetComponent<pauseCountdown>().enabled = false;
                if(gameOver){
                    player.GetComponent<PlayerCrash>().HitPoints=3;
                    player.GetComponent<PlayerCrash>().blinkCount = 0;
                    player.GetComponent<PlayerCrash>().iFrameCount = 0;
                    player.GetComponent<PlayerCrash>().invinci = true;
                    player.GetComponent<PlayerCrash>().pause = false;
                    gameOver=false;
                }
            }
            frames++;
        }
        else
            frames=0;
    }
}

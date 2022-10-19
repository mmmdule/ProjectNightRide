using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Continue : MonoBehaviour
{
    public GameObject ScoreCounter2,ScoreCounter;
    private Text ScoreText;
    private Text ScoreText2;
    private int price;

    private GameObject player,frontWheel,backWheel, countdownCanvas;
    public GameObject gameOverScreen,Cam,coin;
    private GameObject hitUI1,hitUI2,hitUI3/*,hitUI4,hitUI5*/;
    private GameObject endLevel;
    public void Click()
    {
        int difficulty = PlayerPrefs.GetInt("difficulty", 0);
        

        endLevel = GameObject.Find("EndOfLevelTrigger");
        
        frontWheel = GameObject.Find("frontWheel");
        backWheel = GameObject.Find("backWheel");
        
        countdownCanvas=GameObject.Find("countdownCanvas");

        hitUI1 = GameObject.Find("LifeDot1");

        //hitUI4 = GameObject.Find("LifeDot4");
        //hitUI5 = GameObject.Find("LifeDot5");

        ScoreCounter = GameObject.Find("Score");
        ScoreText = ScoreCounter.GetComponent<Text>();                
        ScoreCounter2 = GameObject.Find("ScoreShadow");
        ScoreText2 = ScoreCounter2.GetComponent<Text>();

        Cam=GameObject.Find("Main Camera");

        price = int.Parse(GameObject.Find("TextPrice").GetComponent<Text>().text);
        Debug.Log(price.ToString());
        player=GameObject.Find("player");
        gameOverScreen=GameObject.Find("GameOverCanvas");
        int score = int.Parse(ScoreText.text);
        Debug.Log("Score: " + score.ToString());
        if(score<(-price)){
            gameObject.GetComponent<AudioSource>().PlayOneShot(gameObject.GetComponent<AudioSource>().clip);
        }
        else
        {
            switch(difficulty){
                case 0: case 1:    
                    hitUI2 = GameObject.Find("LifeDot2");
                    hitUI3 = GameObject.Find("LifeDot3");
                    hitUI1.GetComponent<SpriteRenderer>().color=Color.green;            
                    hitUI2.GetComponent<SpriteRenderer>().color=Color.green;
                    hitUI3.GetComponent<SpriteRenderer>().color=Color.green;  
                    break;
                case 2:
                    hitUI1.GetComponent<SpriteRenderer>().color=Color.green;
                    break;
                default:
                    break;
            }         
            //hitUI4.GetComponent<SpriteRenderer>().color=Color.green;
            //hitUI5.GetComponent<SpriteRenderer>().color=Color.green;

            //gameOverScreen.gameObject.SetActive(false);
            gameOverScreen.GetComponent<Canvas>().enabled=false;
            coin.GetComponent<SpriteRenderer>().enabled = false;
            player.SetActive(true);

            /*Moved to pauseCountdown.cs
            
            player.GetComponent<PlayerCrash>().HitPoints=3;
            player.GetComponent<PlayerCrash>().blinkCount = 0;
            player.GetComponent<PlayerCrash>().iFrameCount = 0;
            player.GetComponent<PlayerCrash>().invinci = true;
            
            Moved to pauseCountdown.cs*/

            
            
            
            
            
            /*Removed because of countdown

            GameObject.Find("ButtonCanvas").GetComponent<Canvas>().enabled=true;
            
            player.GetComponent<PlayerMovement>().enabled=true;
            player.GetComponent<PlayerMovement>().speed=player.GetComponent<PlayerMovement>().speedOG;

            Cam.GetComponent<CameraScript>().coinObstacleSpeed=GameObject.Find("PauseButton").GetComponent<PauseButton>().spidNPC;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            Cam.GetComponent<AudioSource>().UnPause();
            
            Removed because of countdown*/
            ScoreText.text = ScoreText.text.Replace(ScoreText.text, (int.Parse(ScoreText.text) + price).ToString());
            ScoreText.SetAllDirty();
            ScoreText2.text = ScoreText2.text.Replace(ScoreText2.text, (int.Parse(ScoreText2.text) + price).ToString());
            ScoreText2.SetAllDirty();
            
            countdownCanvas.GetComponent<pauseCountdown>().gameOver = true;
            countdownCanvas.GetComponent<Canvas>().enabled = true;
            countdownCanvas.GetComponent<pauseCountdown>().enabled = true;
            countdownCanvas.GetComponent<pauseCountdown>().count = true;

            backWheel.GetComponent<WheelSpinFica>().enabled = false;
            frontWheel.GetComponent<WheelSpinFica>().enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedChange : MonoBehaviour
{
    public List<float> changePoints; //points at which the speeds will be altered
    public List<float> changeValues; //the floats that will be added to the speed values

    private GameObject player, camera;
    private PlayerMovement playerMovementScript;
    private PauseContinue pauseContinueScript;

    private CameraScript cameraScript;


    private Button SpeedUpButton;
    private Text SpeedUpText;
    private Image SpeedUpImage;

    private Text TurboText, TurboTextShadow;

    private float OriginalSpeed, OriginalSpeedOG, OriginalNPCSpeed;

    private PlayerCrash playerCrash;

    private bool isHolding;

    public GameObject ScoreCounter;
    private Text ScoreText;
    public GameObject ScoreCounter2;
    private Text ScoreText2;
    
    // Start is called before the first frame update
    void Start()
    {
        ScoreCounter = GameObject.Find("Score");
        ScoreCounter2 = GameObject.Find("ScoreShadow");
        ScoreText2 = ScoreCounter2.GetComponent<Text>();
        ScoreText = ScoreCounter.GetComponent<Text>();  
        //changePoints = new List<float>();
        //changeValues = new List<float>();

        player = GameObject.FindGameObjectWithTag("Player");
        camera = GameObject.Find("Main Camera");

        playerMovementScript = player.GetComponent<PlayerMovement>();
        pauseContinueScript = player.GetComponent<PauseContinue>();
        playerCrash = player.GetComponent<PlayerCrash>();

        OriginalSpeed = playerMovementScript.speed;
        OriginalSpeedOG = playerMovementScript.speedOG;

        cameraScript = camera.GetComponent<CameraScript>();

        OriginalNPCSpeed = cameraScript.coinObstacleSpeed;

        SpeedUpButton = GameObject.Find("SpeedUp").GetComponent<Button>();
        SpeedUpImage = GameObject.Find("SpeedUp").GetComponent<Image>();
        SpeedUpText = GameObject.Find("SpeedUpText").GetComponent<Text>();

        TurboText = GameObject.Find("TurboUI").GetComponent<Text>();
        TurboTextShadow = GameObject.Find("TurboUIShadow").GetComponent<Text>();
    }

    private int frameCount = 0;
    // Update is called once per frame
    void Update()
    {
        if(frameCount >= 6000)
            frameCount = 0;

        if(isHolding ){
            frameCount++;
            if(frameCount%60==0){
                ScoreText.text = ScoreText.text.Replace(ScoreText.text, (int.Parse(ScoreText.text) + 1).ToString());
                ScoreText.SetAllDirty();
                ScoreText2.text = ScoreText2.text.Replace(ScoreText2.text, (int.Parse(ScoreText2.text) + 1).ToString());
                ScoreText2.SetAllDirty();
            }
        }
        if(changePoints.Count>0){
            if(player.transform.position.x >= changePoints[0]){
                SpeedUpButton.enabled = true;
                SpeedUpImage.enabled = true;
                SpeedUpText.enabled = true;

                //Enable Speed Button. On click it will call the ChangeSpeed() method
                
                /*
                playerMovementScript.speedOG += changeValues[0];
                playerMovementScript.speed += changeValues[0];

                cameraScript.coinObstacleSpeed += changeValues[0];
                
                pauseContinueScript.spid += changeValues[0];
                pauseContinueScript.spidNPC += changeValues[0];

                changePoints.RemoveAt(0);
                changeValues.RemoveAt(0);

                */
                //0++;
            }
        }
        if(playerCrash.HitPoints == 0){

            player.GetComponent<PlayerMovement>().enabled=false;
            player.GetComponent<PlayerMovement>().speed=0f;
            camera.GetComponent<CameraScript>().coinObstacleSpeed = 0f;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

            
            TurboText.enabled = false;
            TurboTextShadow.enabled = false;
        }
    }

    public void ChangeSpeed(bool HoldingDown){
        isHolding = HoldingDown;

        if(HoldingDown && !(playerCrash.HitPoints == 0)){
            if(changePoints.Count>=0){
                    playerMovementScript.speedOG += changeValues[0];
                    playerMovementScript.speed += changeValues[0];

                    cameraScript.coinObstacleSpeed += changeValues[0];
                    
                    pauseContinueScript.spid += changeValues[0];
                    pauseContinueScript.spidNPC += changeValues[0];

                    //changePoints.RemoveAt(0);
                    //changeValues.RemoveAt(0);
                    //0++;

                    //SpeedUpButton.enabled = false;
                    //SpeedUpImage.enabled = false;
                    //SpeedUpText.enabled = false;

                    TurboText.enabled = true;
                    TurboTextShadow.enabled = true;

                    //Debug.Log("Turbo Button Visuals OFF");

                    
            }
        }
        else if(!HoldingDown && !(playerCrash.HitPoints == 0)){
            playerMovementScript.speedOG = OriginalSpeedOG;
            playerMovementScript.speed = OriginalSpeed;

            cameraScript.coinObstacleSpeed = OriginalNPCSpeed;

            
            pauseContinueScript.spid -= changeValues[0];
            pauseContinueScript.spidNPC -= changeValues[0];
    
            TurboText.enabled = false;
            TurboTextShadow.enabled = false;
        }
    }
}

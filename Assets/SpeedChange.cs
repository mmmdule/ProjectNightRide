using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedChange : MonoBehaviour
{
    public List<float> changePoints; //points at which the speeds will be altered
    public List<float> changeValues; //the floats that will be added to the speed values

    private GameObject player;
    private PlayerMovement playerMovementScript;
    private PauseContinue pauseContinueScript;

    private CameraScript cameraScript;
    
    // Start is called before the first frame update
    void Start()
    {
        //changePoints = new List<float>();
        //changeValues = new List<float>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerMovementScript = player.GetComponent<PlayerMovement>();
        pauseContinueScript = player.GetComponent<PauseContinue>();

        cameraScript = GameObject.Find("Main Camera").GetComponent<CameraScript>();
    }


    // Update is called once per frame
    void Update()
    {
        if(changePoints.Count>0){
            if(player.transform.position.x >= changePoints[0]){
                //Enable Speed Button. On click it will call the ChangeSpeed() method
                playerMovementScript.speedOG += changeValues[0];
                playerMovementScript.speed += changeValues[0];

                cameraScript.coinObstacleSpeed += changeValues[0];
                
                pauseContinueScript.spid += changeValues[0];
                pauseContinueScript.spidNPC += changeValues[0];

                changePoints.RemoveAt(0);
                changeValues.RemoveAt(0);
                //0++;
            }
        }
        
    }

    public void ChangeSpeed(){
        if(changePoints.Count>0){
            if(player.transform.position.x >= changePoints[0]){
                    playerMovementScript.speedOG += changeValues[0];
                    playerMovementScript.speed += changeValues[0];

                    cameraScript.coinObstacleSpeed += changeValues[0];
                    
                    pauseContinueScript.spid += changeValues[0];
                    pauseContinueScript.spidNPC += changeValues[0];

                    changePoints.RemoveAt(0);
                    changeValues.RemoveAt(0);
                    //0++;
            }
        }
    }
}

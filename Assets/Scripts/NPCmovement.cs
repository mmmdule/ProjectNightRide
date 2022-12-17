using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCmovement : MonoBehaviour
{
    public float speed;

    private Vector3 vectorPos;

    private Collider2D BoxCollider,wallR,wallL;
    
    public GameObject Camera;
    private CameraScript cameraScript;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("Main Camera");

        wallR=GameObject.FindGameObjectWithTag("RightPiece").GetComponent<BoxCollider2D>();
        wallL=GameObject.FindGameObjectWithTag("LeftPiece").GetComponent<BoxCollider2D>();
        BoxCollider = gameObject.GetComponent<BoxCollider2D>();
        //Camera = GameObject.Find("Main Camera");
        speed = Camera.GetComponent<CameraScript>().coinObstacleSpeed;

        cameraScript = Camera.GetComponent<CameraScript>();

        vectorPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        speed = cameraScript.coinObstacleSpeed;
        if (!(BoxCollider.IsTouching(wallL) || BoxCollider.IsTouching(wallR))){
            /*if(transform.rotation.y==180){
                //vectorPos.x += speed;
                transform.position = vectorPos;
            }
            else{*/
                vectorPos.x += speed; 
                transform.position = vectorPos;
            //}
        }
    }
}

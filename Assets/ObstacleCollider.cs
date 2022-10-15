using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollider : MonoBehaviour
{
   public float speed;

    private Vector3 vectorPos;

    private Collider2D BoxCollider,wallR,wallL;
    
    private Transform parentTransform;

    public GameObject Camera;
    
    // Start is called before the first frame update
    void Start()
    {

        wallR=GameObject.FindGameObjectWithTag("RightPiece").GetComponent<BoxCollider2D>();
        wallL=GameObject.FindGameObjectWithTag("LeftPiece").GetComponent<BoxCollider2D>();
        BoxCollider = gameObject.GetComponent<BoxCollider2D>();
        //Camera = GameObject.Find("Main Camera");
        speed = Camera.GetComponent<CameraScript>().coinObstacleSpeed;
        parentTransform = GetComponentInParent<Transform>();
        vectorPos = parentTransform.position;//GetComponentInParent<Transform>().position;
        //vectorPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        gameObject.transform.SetParent(parentTransform);
    }

    // Update is called once per frame
    void Update()
    {
        speed = Camera.GetComponent<CameraScript>().coinObstacleSpeed;
        if (!(BoxCollider.IsTouching(wallL) || BoxCollider.IsTouching(wallR))){
            /*if(transform.rotation.y==180){
                //vectorPos.x += speed;
                transform.position = vectorPos;
            }
            else{*/
                vectorPos.x += speed;
                transform.parent.position = vectorPos;//transform.position = vectorPos;
            //}
        }
    }
}

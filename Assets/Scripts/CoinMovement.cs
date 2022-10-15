using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    private Vector3 vectPos;
    public float speed;
    private Collider2D BoxCollider,wallR,wallL;
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        wallR=GameObject.FindGameObjectWithTag("RightPiece").GetComponent<BoxCollider2D>();
        wallL=GameObject.FindGameObjectWithTag("LeftPiece").GetComponent<BoxCollider2D>();
        BoxCollider = gameObject.GetComponent<CircleCollider2D>();
        
        speed = Camera.GetComponent<CameraScript>().coinObstacleSpeed;
        vectPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        speed = Camera.GetComponent<CameraScript>().coinObstacleSpeed;
        vectPos.x += speed;
        if (!(BoxCollider.IsTouching(wallL) || BoxCollider.IsTouching(wallR))){
                transform.position = vectPos;//new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        }
    }
}

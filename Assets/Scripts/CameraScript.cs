using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private float speed;
    public float coinObstacleSpeed;
    private Vector3 MoveVector;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        speed = GameObject.Find("player").GetComponent<PlayerMovement>().speed;
        MoveVector = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        speed = GameObject.Find("player").GetComponent<PlayerMovement>().speed;
        //transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        MoveVector.x += speed;
        transform.position = MoveVector;//new Vector3(transform.position.x + speed, transform.position.y, transform.position.z); 
    }
}

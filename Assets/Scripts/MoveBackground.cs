using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
   public GameObject LeftPiece, RightPiece, CenterPiece;
    public Rigidbody2D LeftBody, RightBody;
    // Start is called before the first frame update
    void Start()
    {
        CenterPiece = GameObject.Find("CenterPiece");
        LeftPiece = GameObject.Find("LeftPiece");
        RightPiece = GameObject.Find("RightPiece");
        LeftBody = LeftPiece.GetComponent<Rigidbody2D>();
        RightBody = RightPiece.GetComponent<Rigidbody2D>();
    }

    /* Update is called once per frame
    //void Update()
    {
        
        if (gameObject.GetComponent<Collider2D>().IsTouching(RightPiece.GetComponent<Collider2D>())){
            RightPiece.GetComponent<Collider2D>().enabled = false;
            LeftPiece.GetComponent<Collider2D>().enabled = true;
            LeftBody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation; 
            CenterPiece.transform.position = new Vector3(CenterPiece.transform.position.x + 114.75f,CenterPiece.transform.position.y,CenterPiece.transform.position.z);
            LeftPiece.transform.position = new Vector3(LeftPiece.transform.position.x + 114.75f,LeftPiece.transform.position.y,LeftPiece.transform.position.z);            
            LeftBody.constraints = RigidbodyConstraints2D.FreezeAll; 
        }
        else if (gameObject.GetComponent<Collider2D>().IsTouching(LeftPiece.GetComponent<Collider2D>())){
            LeftPiece.GetComponent<Collider2D>().enabled = false;
            RightPiece.GetComponent<Collider2D>().enabled = true;
            RightBody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation; 
            RightPiece.transform.position = new Vector3(RightPiece.transform.position.x + 114.75f,RightPiece.transform.position.y,RightPiece.transform.position.z);            
            RightBody.constraints = RigidbodyConstraints2D.FreezeAll;//RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation; 
        }
    }*/


    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "RightPiece"){
            // RightPiece.GetComponent<Collider2D>().enabled = false;
            // LeftPiece.GetComponent<Collider2D>().enabled = true;
            // LeftBody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation; 
            CenterPiece.transform.position = new Vector3(CenterPiece.transform.position.x + 114.75f,CenterPiece.transform.position.y,CenterPiece.transform.position.z);
            LeftPiece.transform.position = new Vector3(LeftPiece.transform.position.x + 114.75f,LeftPiece.transform.position.y,LeftPiece.transform.position.z);            
            // LeftBody.constraints = RigidbodyConstraints2D.FreezeAll; //Da drugi objekti (pare i Zastave) ne bi mogli da ga pomere, samo igrac
            return ;
        }
        else if (collision.gameObject.tag == "LeftPiece"){
            // LeftPiece.GetComponent<Collider2D>().enabled = false;
            // RightPiece.GetComponent<Collider2D>().enabled = true;
            // RightBody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation; 
            RightPiece.transform.position = new Vector3(RightPiece.transform.position.x + 114.75f,RightPiece.transform.position.y,RightPiece.transform.position.z);            
            // RightBody.constraints = RigidbodyConstraints2D.FreezeAll;//RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation; 
        }
    }

}

//115.213LC
//115.64R


/* BACKUP OF CODE THAT WORKS WITH COLLIDERS
*
public GameObject LeftPiece, RightPiece, CenterPiece;
    public Rigidbody2D LeftBody, RightBody;
    // Start is called before the first frame update
    void Start()
    {
        CenterPiece = GameObject.Find("CenterPiece");
        LeftPiece = GameObject.Find("LeftPiece");
        RightPiece = GameObject.Find("RightPiece");
        LeftBody = LeftPiece.GetComponent<Rigidbody2D>();
        RightBody = RightPiece.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Collider2D>().IsTouching(RightPiece.GetComponent<Collider2D>())){
            RightPiece.GetComponent<Collider2D>().enabled = false;
            LeftPiece.GetComponent<Collider2D>().enabled = true;
            LeftBody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation; 
            CenterPiece.transform.position = new Vector3(CenterPiece.transform.position.x + 114.75f,CenterPiece.transform.position.y,CenterPiece.transform.position.z);
            LeftPiece.transform.position = new Vector3(LeftPiece.transform.position.x + 114.75f,LeftPiece.transform.position.y,LeftPiece.transform.position.z);            
            LeftBody.constraints = RigidbodyConstraints2D.FreezeAll; 
        }
        else if (gameObject.GetComponent<Collider2D>().IsTouching(LeftPiece.GetComponent<Collider2D>())){
            LeftPiece.GetComponent<Collider2D>().enabled = false;
            RightPiece.GetComponent<Collider2D>().enabled = true;
            RightBody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation; 
            RightPiece.transform.position = new Vector3(RightPiece.transform.position.x + 114.75f,RightPiece.transform.position.y,RightPiece.transform.position.z);            
            RightBody.constraints = RigidbodyConstraints2D.FreezeAll;//RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation; 
        }
    }
*
*BACKUP OF CODE THAT WORKS WITH COLLIDERS
*/
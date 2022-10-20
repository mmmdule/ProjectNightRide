using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed,speedOG;
    private SpriteRenderer spriteR;
    private int sortOrder;
    private SpriteRenderer[] damage;
   /* public GameObject leftPiece;
    public GameObject centerPiece;
    public GameObject rightPiece;*/
    void Start()
    {
        /*leftPiece = GameObject.Find("LeftPiece");  
        centerPiece = GameObject.Find("CenterPiece"); 
        rightPiece = GameObject.Find("RightPiece"); */
        spriteR = gameObject.GetComponent<SpriteRenderer>();

        damage = new SpriteRenderer[4];
        for(int i = 1; i <= 4; i++){
            damage[i-1] = GameObject.Find("crack" + i).GetComponent<SpriteRenderer>();
        }
    }
    //sorting order starts at 4

    // Update is called once per frame
    void Update()
    {
        sortOrder = spriteR.sortingOrder;
        //-5.440001
        if ((Input.GetKeyDown("down") || Input.GetKeyDown("s")) && sortOrder < 7){ //transform.position.y>-5.43f){
            transform.position = new Vector3(transform.position.x, transform.position.y - 1.02f, transform.position.z);
            spriteR.sortingOrder +=1;
            damage[0].sortingOrder += 1;
            damage[1].sortingOrder += 1;
            damage[2].sortingOrder += 1;
            damage[3].sortingOrder += 1;
        }
        if ((Input.GetKeyDown("up") || Input.GetKeyDown("w")) && (sortOrder > 4)){// && transform.position.y!=-2.38f){
            transform.position = new Vector3(transform.position.x, transform.position.y + 1.02f, transform.position.z);
            spriteR.sortingOrder -=1;
            damage[0].sortingOrder -= 1;
            damage[1].sortingOrder -= 1;
            damage[2].sortingOrder -= 1;
            damage[3].sortingOrder -= 1;
        }
        transform.position = new Vector3(transform.position.x + speed , transform.position.y, transform.position.z);
        
        /*if(transform.position.x%23.43f==0){
            leftPiece.transform.position = new Vector3(leftPiece.transform.position.x + 115.64f, leftPiece.transform.position.y, leftPiece.transform.position.z);
            centerPiece.transform.position = new Vector3(centerPiece.transform.position.x + 115.64f, centerPiece.transform.position.y, centerPiece.transform.position.z);
        }
        if(transform.position.x%64.29==0){
            rightPiece.transform.position = new Vector3(rightPiece.transform.position.x + 115.213f, rightPiece.transform.position.y, rightPiece.transform.position.z);
        }*/

        //23.44
    }
}

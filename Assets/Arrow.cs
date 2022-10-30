using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Arrow : MonoBehaviour
{
    //public float speed,speedOG;
    private SpriteRenderer spriteR;
    private GameObject player;
    private int sortOrder;
    private SpriteRenderer[] damage;

    private Vector3 moveVector;
    private float lerpSpeed = 17.0f;
    private IEnumerator movementCoroutine;
    private Arrow upArrow, downArrow;


    void Start(){
        player = GameObject.Find("player");
        //lerpSpeed = player.GetComponent<PlayerMovement>().speed;
        spriteR = player.GetComponent<SpriteRenderer>();

        damage = new SpriteRenderer[4];
        for(int i = 1; i <= 4; i++){
            damage[i-1] = GameObject.Find("crack" + i).GetComponent<SpriteRenderer>();
        }

        moveVector = new Vector3();

        upArrow = GameObject.Find("UpArrow").GetComponent<Arrow>();
        downArrow = GameObject.Find("DownArrow").GetComponent<Arrow>();
    }
    
    public void KlikMove(string direction)
    {
        
        sortOrder = spriteR.sortingOrder;
        

        if (direction=="down" && sortOrder < 7){
            upArrow.StopAllCoroutines();
            downArrow.StopAllCoroutines();

            moveVector = player.transform.position;
            moveVector.y -=  1.02f;
            /*player.transform.position = moveVector*/;             //new Vector3(player.transform.position.x, player.transform.position.y - 1.02f, player.transform.position.z);
            




            switch(spriteR.sortingOrder + 1){
                case 4:
                    moveVector.y =  -2.38f;
                    break;
                case 5:
                    moveVector.y =  -3.4f;
                    break;
                case 6:
                    moveVector.y =  -4.42f;
                    break;
                case 7:
                    moveVector.y =  -5.44f;
                    break;
            }
            
            spriteR.sortingOrder +=1;
            damage[0].sortingOrder = spriteR.sortingOrder + 1;
            damage[1].sortingOrder = spriteR.sortingOrder + 1;
            damage[2].sortingOrder = spriteR.sortingOrder + 1;
            damage[3].sortingOrder = spriteR.sortingOrder + 1;
        }
        if (direction=="up" && sortOrder > 4){
            upArrow.StopAllCoroutines();
            downArrow.StopAllCoroutines();

            moveVector = player.transform.position;
            moveVector.y +=  1.02f;
            /*player.transform.position = moveVector;*/             //new Vector3(player.transform.position.x, player.transform.position.y + 1.02f, player.transform.position.z);

            switch(spriteR.sortingOrder - 1){
                case 4:
                    moveVector.y =  -2.38f;
                    break;
                case 5:
                    moveVector.y =  -3.4f;
                    break;
                case 6:
                    moveVector.y =  -4.42f;
                    break;
                case 7:
                    moveVector.y =  -5.44f;
                    break;
            }
            
            
            spriteR.sortingOrder -=1;
            damage[0].sortingOrder = spriteR.sortingOrder + 1;
            damage[1].sortingOrder = spriteR.sortingOrder + 1;
            damage[2].sortingOrder = spriteR.sortingOrder + 1;
            damage[3].sortingOrder = spriteR.sortingOrder + 1;
        }
        //transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        
        movementCoroutine = SmoothTranlation(player.transform.position, moveVector, lerpSpeed);
        StartCoroutine(movementCoroutine);

        //23.44
    }

    IEnumerator SmoothTranlation(Vector3 playerPos, Vector3 targetVector, float speed) {
        //while (Math.Abs(player.transform.position.y - targetVector.y) > 0.01f) {
        while (player.transform.position.y != targetVector.y) {
            player.transform.position = new Vector3(player.transform.position.x, Mathf.Lerp(player.transform.position.y, targetVector.y, Time.deltaTime * speed), player.transform.position.z);

            yield return null;
        }
        /*while (Math.Abs(player.transform.position.y - targetVector.y) < 0.01f) {
            //player.transform.position = Vector3.Lerp (player.transform.position, targetVector, Time.deltaTime * speed);

            //player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, Mathf.Lerp(player.transform.position.z, transform.position.z, Time.deltaTime * 1));
 
     
            yield return null;
        }*/
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    //public float speed,speedOG;
    private SpriteRenderer spriteR;
    private GameObject player;
    private int sortOrder;
    private SpriteRenderer[] damage;

    void Start(){
        player = GameObject.Find("player");
        spriteR = player.GetComponent<SpriteRenderer>();

        damage = new SpriteRenderer[4];
        for(int i = 1; i <= 4; i++){
            damage[i-1] = GameObject.Find("crack" + i).GetComponent<SpriteRenderer>();
        }
    }
    
    public void KlikMove(string direction)
    {
        sortOrder = spriteR.sortingOrder;
        if (direction=="down" && sortOrder < 7){
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 1.02f, player.transform.position.z);
            spriteR.sortingOrder +=1;
            damage[0].sortingOrder = spriteR.sortingOrder;
            damage[1].sortingOrder = spriteR.sortingOrder;
            damage[2].sortingOrder = spriteR.sortingOrder;
            damage[3].sortingOrder = spriteR.sortingOrder;
        }
        if (direction=="up" && sortOrder > 4){
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1.02f, player.transform.position.z);
            spriteR.sortingOrder -=1;
            damage[0].sortingOrder = spriteR.sortingOrder;
            damage[1].sortingOrder = spriteR.sortingOrder;
            damage[2].sortingOrder = spriteR.sortingOrder;
            damage[3].sortingOrder = spriteR.sortingOrder;
        }
        //transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        
        //23.44
    }
}

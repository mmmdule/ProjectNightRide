using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    private int song;
    // Start is called before the first frame update
    void Start()
    {
        song = UnityEngine.Random.Range(1,4);
        if(song==1){
            GameObject.Find("player").GetComponent<AudioSource>().Play();            
            GameObject.Find("player").GetComponent<AudioSource>().loop=true;
            GameObject.Find("player").GetComponent<PlayerMovement>().speed=0.115f;
        }
        else if(song==2)
        {
            GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();            
            GameObject.Find("Main Camera").GetComponent<AudioSource>().loop=true;
            GameObject.Find("player").GetComponent<PlayerMovement>().speed=0.125f;
        }
        else if (song==3){                
            GameObject.Find("CenterPiece").GetComponent<AudioSource>().Play();            
            GameObject.Find("CenterPiece").GetComponent<AudioSource>().loop=true;
            GameObject.Find("player").GetComponent<PlayerMovement>().speed=0.155f;
        }
        Debug.Log("Song = " + song.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPause : MonoBehaviour
{
    public GameObject pauseCanvas,ButtonCanvas;
    public GameObject Camera,Player;
    public int count;
    public float spid,spidNPC;
    private Canvas GameOverCanvas;
    // Start is called before the first frame update
    void Start()
    {
        pauseCanvas=GameObject.FindGameObjectWithTag("Pause");
        Camera = GameObject.Find("Main Camera");
        Player = GameObject.Find("player");
        count = 1;
        spid = Player.GetComponent<PlayerMovement>().speed;
        spidNPC = Camera.GetComponent<CameraScript>().coinObstacleSpeed;
        Debug.Log("Spid = " + spid.ToString());
        GameOverCanvas = GameObject.Find("GameOverCanvas").GetComponent<Canvas>();

    }

    // Update is called once per frame
    void Update()
    {
        /*if(GameOverCanvas.enabled==false){
            if (Input.GetKeyDown("escape")){
                count++;
                if(count%2==0){
                    ButtonCanvas=GameObject.Find("ButtonCanvas");
                    ButtonCanvas.SetActive(false);
                    gameObject.GetComponent<Canvas>().enabled=true;
                    Player.GetComponent<PlayerMovement>().speed=0f;
                    Player.GetComponent<PlayerMovement>().enabled=false;
                    Camera.GetComponent<CameraScript>().coinObstacleSpeed=0f;
                    Camera.GetComponent<AudioSource>().Pause();
                }
                else{
                    ButtonCanvas=GameObject.Find("ButtonCanvas");
                    ButtonCanvas.SetActive(true);
                    gameObject.GetComponent<Canvas>().enabled=false;                
                    Player.GetComponent<PlayerMovement>().speed=spid;
                    Player.GetComponent<PlayerMovement>().enabled=true;                
                    Camera.GetComponent<CameraScript>().coinObstacleSpeed=spidNPC;
                    Camera.GetComponent<AudioSource>().UnPause();
                }
            }
        }*/
    }
}
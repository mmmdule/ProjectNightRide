using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    //iz CoinMovement
    public float speed;
    private Collider2D BoxCollider,wallR,wallL;
    public GameObject Camera;
    //iz CoinMovement

    private Vector3 vectorPos;
    public bool moving; //da li se krece ili ne

    private Collider2D objectCollider;
    private Collider2D playerCollider;
    public GameObject ScoreCounter;
    private Text ScoreText;
    public GameObject ScoreCounter2, player;
    private Text ScoreText2;
    public int value = 1;
    private float x;

    private SpriteRenderer sprite;
    private CoinMovement scriptMove;
    // Start is called before the first frame update
    void Start()
    {
        //iz CoinMovement
        wallR=GameObject.FindGameObjectWithTag("RightPiece").GetComponent<BoxCollider2D>();
        wallL=GameObject.FindGameObjectWithTag("LeftPiece").GetComponent<BoxCollider2D>();
        
        BoxCollider = gameObject.GetComponent<CircleCollider2D>();
        
        speed = 0f;//Camera.GetComponent<CameraScript>().coinObstacleSpeed;
        //iz CoinMovement

        vectorPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        objectCollider = gameObject.GetComponent<CircleCollider2D>();
        playerCollider = GameObject.Find("player").GetComponent<BoxCollider2D>();
        ScoreCounter = GameObject.Find("Score");        
        ScoreCounter2 = GameObject.Find("ScoreShadow");
        ScoreText2 = ScoreCounter2.GetComponent<Text>();
        ScoreText = ScoreCounter.GetComponent<Text>();        
        player = GameObject.Find("player");

        sprite = gameObject.GetComponent<SpriteRenderer>();
        scriptMove = gameObject.GetComponent<CoinMovement>();
    }

    // Update is called once per frame
    void Update()
    {   
        //iz CoinMovement
        if(moving){
            speed = Camera.GetComponent<CameraScript>().coinObstacleSpeed;
            vectorPos.x += speed; 
            transform.position = vectorPos;
        }

        //x = gameObject.transform.position.x;
        transform.Rotate (Vector3.up * -4); //ROTATION
        //if (player.transform.position.x - x > 15f)            
            //gameObject.SetActive(false);//GameObject.Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player"){
                ScoreText.text = ScoreText.text.Replace(ScoreText.text, (int.Parse(ScoreText.text) + value).ToString());
                ScoreText.SetAllDirty();
                ScoreText2.text = ScoreText2.text.Replace(ScoreText2.text, (int.Parse(ScoreText2.text) + value).ToString());
                ScoreText2.SetAllDirty();
                //GameObject.Destroy(gameObject); //RemoveObject();
                gameObject.SetActive(false);
        }
    }

    void RemoveObject(){
        //GameObject.DestroyImmediate(gameObject);
        
        /*objectCollider.enabled = false;
        sprite.enabled = false;
        scriptMove.enabled = false;
        gameObject.SetActive(false);*/

        GameObject.Destroy(gameObject);
    }
}

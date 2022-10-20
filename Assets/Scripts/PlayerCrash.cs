using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrash : MonoBehaviour
{
    private Collider2D colliderPlayer;
    public Canvas gameOverScreen;
    //private GameObject canvasGroup;
    private AudioSource MainCamAudio;
    public GameObject ButtonCanvas,player, coin;
    private AudioSource playerAudio;
    private Rigidbody2D rbPlayer;

    public int HitPoints;

    private GameObject hitUI1,hitUI2,hitUI3, hitUI4, hitUI5;
    public int blinkCount,iFrameCount;//blinkEnemy;
    private GameObject crashedNPC;
    public bool invinci,pause;
    private GameObject endLevel;

    void Start()
    {
        endLevel = GameObject.Find("EndOfLevelTrigger");
        //canvasGroup = GameObject.Find("Canvas Group");

        invinci=false;
        pause = false;
        iFrameCount = 0;

        colliderPlayer = gameObject.GetComponent<BoxCollider2D>();
        MainCamAudio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        playerAudio = gameObject.GetComponent<AudioSource>();
        rbPlayer = gameObject.GetComponent<Rigidbody2D>();
        ButtonCanvas=GameObject.Find("ButtonCanvas");
        player = GameObject.Find("player");

        hitUI1 = GameObject.Find("LifeDot1");
        hitUI1.GetComponent<SpriteRenderer>().color=Color.green;
        hitUI2 = GameObject.Find("LifeDot2");
        hitUI2.GetComponent<SpriteRenderer>().color=Color.green;
        hitUI3 = GameObject.Find("LifeDot3");
        hitUI3.GetComponent<SpriteRenderer>().color=Color.green;
        hitUI4 = GameObject.Find("LifeDot4");
        hitUI4.GetComponent<SpriteRenderer>().color=Color.green;
        hitUI5 = GameObject.Find("LifeDot5");
        hitUI5.GetComponent<SpriteRenderer>().color=Color.green;

        crashedNPC = null;

        int difficulty = PlayerPrefs.GetInt("difficulty", 0);
        switch(difficulty){
            case 0:
                HitPoints = 5;
                break;
            case 1:
                HitPoints = 3;
                hitUI4.SetActive(false);
                hitUI5.SetActive(false);
                break;
            case 2:
                HitPoints = 1;
                hitUI2.SetActive(false);
                hitUI3.SetActive(false);
                hitUI4.SetActive(false);
                hitUI5.SetActive(false);
                break;
            default:
                break;
        }
        //HitPoints = 3;
        blinkCount = 0;
        //blinkEnemy = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(HitPoints > 0 && crashedNPC!=null){//if(HitPoints==2 || HitPoints==1){
            if(crashedNPC.activeInHierarchy!=false){
                if(blinkCount<120){
                    if(blinkCount%10==0)
                        crashedNPC.GetComponent<SpriteRenderer>().enabled = false;
                    else
                        crashedNPC.GetComponent<SpriteRenderer>().enabled = true;
                }
                blinkCount++;
            }
            else
                blinkCount=0;
        }


        if(invinci && !pause){
                if(iFrameCount<=120){
                    if(iFrameCount%20==0 && iFrameCount>0)
                        gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    else
                        gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    iFrameCount++;
                }
                else{
                    iFrameCount=0;
                    gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    invinci = false;
                }
        }
        /*
        if(HitPoints==2){
            if(crashedNPC.activeInHierarchy!=false){
                if(blinkCount<120){
                    if(blinkCount%10==0)
                        crashedNPC.GetComponent<SpriteRenderer>().enabled = false;
                    else
                        crashedNPC.GetComponent<SpriteRenderer>().enabled = true;
                }
                blinkCount++;
            }
            else
                blinkCount=0;
        }
        
        else if(HitPoints==1){
            if(crashedNPC.activeInHierarchy!=false){
                if(blinkCount<120){
                    if(blinkCount%10==0)
                        crashedNPC.GetComponent<SpriteRenderer>().enabled = false;
                    else
                        crashedNPC.GetComponent<SpriteRenderer>().enabled = true;
                }
                blinkCount++;
            }
            else
                blinkCount=0;
        }
        */
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Obstacle"){
            if(invinci==false){
                crashedNPC = collision.gameObject;            
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                
                hitUI1.GetComponent<AudioSource>().PlayOneShot(hitUI1.GetComponent<AudioSource>().clip);
                
                HitPoints--;
                invinci = true;
            }
            else{
                crashedNPC = collision.gameObject;            
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            
            if(HitPoints==4){
                //hitUI5.GetComponent<AudioSource>().PlayOneShot(hitUI5.GetComponent<AudioSource>().clip);
                hitUI5.GetComponent<SpriteRenderer>().color=Color.gray;
            }
            else if(HitPoints==3){
                //hitUI4.GetComponent<AudioSource>().PlayOneShot(hitUI4.GetComponent<AudioSource>().clip);
                hitUI4.GetComponent<SpriteRenderer>().color=Color.gray;
                
                hitUI3.GetComponent<SpriteRenderer>().color=Color.yellow;
                hitUI2.GetComponent<SpriteRenderer>().color=Color.yellow;
                hitUI1.GetComponent<SpriteRenderer>().color=Color.yellow;

            }
            if(HitPoints==2){
                if(invinci==false)
                    hitUI3.GetComponent<AudioSource>().PlayOneShot(hitUI3.GetComponent<AudioSource>().clip);
                hitUI3.GetComponent<SpriteRenderer>().color=Color.gray;
                
                hitUI2.GetComponent<SpriteRenderer>().color=Color.yellow;
                hitUI1.GetComponent<SpriteRenderer>().color=Color.yellow;

            }
            else if(HitPoints==1){
                if(invinci==false)
                    hitUI2.GetComponent<AudioSource>().PlayOneShot(hitUI2.GetComponent<AudioSource>().clip);
                hitUI2.GetComponent<SpriteRenderer>().color=Color.gray;
                
                hitUI1.GetComponent<SpriteRenderer>().color=Color.red;

            }
            else if (HitPoints==0){
                
                endLevel.GetComponent<EndOfLevel>().isGameOver = true;
        
                hitUI1.GetComponent<SpriteRenderer>().color=Color.gray;

                ButtonCanvas.GetComponent<Canvas>().enabled=false;

                player.GetComponent<PlayerMovement>().enabled=false;
                gameObject.GetComponent<AudioSource>().PlayOneShot(gameObject.GetComponent<AudioSource>().clip);
                //rbPlayer.constraints = RigidbodyConstraints2D.FreezeAll;

                gameOverScreen.GetComponent<Canvas>().enabled=true;
                
                //OVDE DODAJ DA SE GAME OVER STVORI TAKO STO SE OVAJ ALPHA MENJA
                //canvasGroup.GetComponent<CanvasGroup>().Aplha += 0.005f;


                coin.GetComponent<SpriteRenderer>().enabled = true;
                collision.gameObject.SetActive(false);

                MainCamAudio.Pause();

                gameObject.GetComponent<PlayerMovement>().speed=0f;
                GameObject.Find("Main Camera").GetComponent<CameraScript>().coinObstacleSpeed = 0f;
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                //If the GameObject's tag matches the one you suggest, output this message in the console
            }
        }
    }
}


/* OLD WORKING CODE
 *
    private Collider2D colliderPlayer;
    public Canvas gameOverScreen;
    private AudioSource MainCamAudio;
    public GameObject ButtonCanvas,player, coin;
    private AudioSource playerAudio;
    private Rigidbody2D rbPlayer;

    public int HitPoints;

    private GameObject hitUI1,hitUI2,hitUI3;
    //hitUI4,hitUI5;

    public int blinkCount;//blinkEnemy;
    private GameObject crashedNPC;
    void Start()
    {
        colliderPlayer = gameObject.GetComponent<BoxCollider2D>();
        MainCamAudio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        playerAudio = gameObject.GetComponent<AudioSource>();
        rbPlayer = gameObject.GetComponent<Rigidbody2D>();
        ButtonCanvas=GameObject.Find("ButtonCanvas");
        player = GameObject.Find("player");

        hitUI1 = GameObject.Find("LifeDot1");
        hitUI1.GetComponent<SpriteRenderer>().color=Color.green;
        hitUI2 = GameObject.Find("LifeDot2");
        hitUI2.GetComponent<SpriteRenderer>().color=Color.green;
        hitUI3 = GameObject.Find("LifeDot3");
        hitUI3.GetComponent<SpriteRenderer>().color=Color.green;
        // hitUI4 = GameObject.Find("LifeDot4");
        // hitUI4.GetComponent<SpriteRenderer>().color=Color.green;
        // hitUI5 = GameObject.Find("LifeDot5");
        // hitUI5.GetComponent<SpriteRenderer>().color=Color.green;

        HitPoints = 3;
        blinkCount = 0;
        //blinkEnemy = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(HitPoints==2 || HitPoints==1){
            if(crashedNPC.activeInHierarchy!=false){
                if(blinkCount<120){
                    if(blinkCount%10==0)
                        crashedNPC.GetComponent<SpriteRenderer>().enabled = false;
                    else
                        crashedNPC.GetComponent<SpriteRenderer>().enabled = true;
                }
                blinkCount++;
            }
            else
                blinkCount=0;
        }
        // if(HitPoints==2){
        //     if(crashedNPC.activeInHierarchy!=false){
        //         if(blinkCount<120){
        //             if(blinkCount%10==0)
        //                 crashedNPC.GetComponent<SpriteRenderer>().enabled = false;
        //             else
        //                 crashedNPC.GetComponent<SpriteRenderer>().enabled = true;
        //         }
        //         blinkCount++;
        //     }
        //     else
        //         blinkCount=0;
        // }
        
        // else if(HitPoints==1){
        //     if(crashedNPC.activeInHierarchy!=false){
        //         if(blinkCount<120){
        //             if(blinkCount%10==0)
        //                 crashedNPC.GetComponent<SpriteRenderer>().enabled = false;
        //             else
        //                 crashedNPC.GetComponent<SpriteRenderer>().enabled = true;
        //         }
        //         blinkCount++;
        //     }
        //     else
        //         blinkCount=0;
        // }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Obstacle"){

            crashedNPC = collision.gameObject;            
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;

            HitPoints--;
            // if(HitPoints==4){
            //     hitUI5.GetComponent<AudioSource>().PlayOneShot(hitUI5.GetComponent<AudioSource>().clip);
            //     hitUI5.GetComponent<SpriteRenderer>().color=Color.gray;
            // }
            // else if(HitPoints==3){
            //     hitUI4.GetComponent<AudioSource>().PlayOneShot(hitUI4.GetComponent<AudioSource>().clip);
            //     hitUI4.GetComponent<SpriteRenderer>().color=Color.gray;
                
            //     hitUI3.GetComponent<SpriteRenderer>().color=Color.yellow;
            //     hitUI2.GetComponent<SpriteRenderer>().color=Color.yellow;
            //     hitUI1.GetComponent<SpriteRenderer>().color=Color.yellow;

            // }
            if(HitPoints==2){
                hitUI3.GetComponent<AudioSource>().PlayOneShot(hitUI3.GetComponent<AudioSource>().clip);
                hitUI3.GetComponent<SpriteRenderer>().color=Color.gray;
                
                hitUI2.GetComponent<SpriteRenderer>().color=Color.yellow;
                hitUI1.GetComponent<SpriteRenderer>().color=Color.yellow;

            }
            else if(HitPoints==1){
                hitUI2.GetComponent<AudioSource>().PlayOneShot(hitUI2.GetComponent<AudioSource>().clip);
                hitUI2.GetComponent<SpriteRenderer>().color=Color.gray;
                
                hitUI1.GetComponent<SpriteRenderer>().color=Color.red;

            }
            else if (HitPoints==0){
                hitUI1.GetComponent<SpriteRenderer>().color=Color.gray;

                ButtonCanvas.GetComponent<Canvas>().enabled=false;

                player.GetComponent<PlayerMovement>().enabled=false;
                gameObject.GetComponent<AudioSource>().PlayOneShot(gameObject.GetComponent<AudioSource>().clip);
                //rbPlayer.constraints = RigidbodyConstraints2D.FreezeAll;

                gameOverScreen.GetComponent<Canvas>().enabled=true;
                coin.GetComponent<SpriteRenderer>().enabled = true;
                collision.gameObject.SetActive(false);

                MainCamAudio.Pause();

                gameObject.GetComponent<PlayerMovement>().speed=0f;
                GameObject.Find("Main Camera").GetComponent<CameraScript>().coinObstacleSpeed = 0f;
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                //If the GameObject's tag matches the one you suggest, output this message in the console
            }
        }
    }
}
 *
    OLD ONE HIT WORKING CODE*/
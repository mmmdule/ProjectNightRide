using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndOfLevel : MonoBehaviour
{
    private BoxCollider2D objectCollider;
    private BoxCollider2D playerCollider;
    public string HighScorePrefName;
    public GameObject endOfLevel,newHighScore,newHighScoreShadow;
    private GameObject PauseButton;

    private GameObject Congrats,CongratsShadow, textExit, textExitShadow, button;
    private AudioSource song; 
    int newScore;
    public bool isPaused, isCountingDown, isGameOver;
    //bool reachedEnd;
    // Start is called before the first frame update
    void Start()
    {
        objectCollider = gameObject.GetComponent<BoxCollider2D>();        
        playerCollider = GameObject.Find("player").GetComponent<BoxCollider2D>();
        PauseButton = GameObject.Find("PauseButton");
        Congrats = GameObject.Find("Congratulations");
        CongratsShadow = GameObject.Find("CongratulationsShadow");
        endOfLevel = GameObject.Find("EndOfLevelCanvas");
        textExit = GameObject.Find("PressEnter");
        textExitShadow = GameObject.Find("PressEnterShadow");
        button = GameObject.Find("EndLevelButton");
        song = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        //reachedEnd = false;

    int difficulty = PlayerPrefs.GetInt("difficulty", 0);
        switch(difficulty){
            case 0:
                break;
            case 1:
                HighScorePrefName += "Medium";
                break;
            case 2:
                HighScorePrefName += "Hard";
                break;
            default:
                break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(reachedEnd){
            if(!song.isPlaying && !isPaused && !isCountingDown && !isGameOver){
                //iz funkcije koja je ranije bila kolizija EndLevelTrigger-a sa Player-om
                Debug.Log("Hit end.");
                PauseButton.SetActive(false);
                //reachedEnd = true;
                newScore=int.Parse(GameObject.Find("Score").GetComponent<Text>().text); 
                endOfLevel.GetComponent<Canvas>().enabled=true;
                if(newScore>0){
                    if(newScore > PlayerPrefs.GetInt(HighScorePrefName)){
                        newHighScore.SetActive(true);
                        newHighScoreShadow.SetActive(true);
                        PlayerPrefs.SetInt(HighScorePrefName , newScore);
                        PlayerPrefs.Save();
                        Debug.Log("New High Score is " + newScore.ToString());
                    }
                }                       
                else{
                    Congrats.GetComponent<Text>().text="KRAJ NIVOA";//"END OF LEVEL";
                    CongratsShadow.GetComponent<Text>().text="KRAJ NIVOA";//"END OF LEVEL";
                    newHighScore.SetActive(false);
                    newHighScoreShadow.SetActive(false);
                }
                GameObject[] vehicles = GameObject.FindGameObjectsWithTag("Obstacle");
                GameObject[] cones = GameObject.FindGameObjectsWithTag("Cone");
                if(vehicles!=null){
                    for (int i = 0; i < vehicles.Length; i++){
                        if(!vehicles[i].GetComponent<Renderer>().isVisible)
                            vehicles[i].SetActive(false);
                    }
                }
                if(cones!=null){
                    for (int i = 0; i < cones.Length; i++){
                        if(!cones[i].GetComponent<Renderer>().isVisible)
                            cones[i].SetActive(false);
                    }
                }
            StartCoroutine(exitDelay(3.75f));
                /*//iz funkcije koja je ranije bila kolizija EndLevelTrigger-a sa Player-om

                    textExit.GetComponent<Text>().enabled = true;
                    textExitShadow.GetComponent<Text>().enabled = true;
                    button.GetComponent<Button>().enabled = true;
                    */
            }
        //}
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player"){     //if(objectCollider.IsTouching(playerCollider)){
            Debug.Log("Hit end.");
            PauseButton.SetActive(false);
            //reachedEnd = true;
            newScore=int.Parse(GameObject.Find("Score").GetComponent<Text>().text); 
            endOfLevel.GetComponent<Canvas>().enabled=true;
            if(newScore>0){
                if(newScore > PlayerPrefs.GetInt(HighScorePrefName)){
                    newHighScore.SetActive(true);
                    newHighScoreShadow.SetActive(true);
                    PlayerPrefs.SetInt(HighScorePrefName , newScore);
                    PlayerPrefs.Save();
                    Debug.Log("New High Score is " + newScore.ToString());
                }
            }                       
            else{
                Congrats.GetComponent<Text>().text="KRAJ NIVOA";//"END OF LEVEL";
                CongratsShadow.GetComponent<Text>().text="KRAJ NIVOA";//"END OF LEVEL";
                newHighScore.SetActive(false);
                newHighScoreShadow.SetActive(false);
            }
            objectCollider.enabled = false;
            //gameObject.SetActive(false);
        }

    }
    IEnumerator exitDelay(float waitSeconds)
    {
        //Print the time of when the function is first called.
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(waitSeconds);

        //iz funkcije koja je ranije bila kolizija EndLevelTrigger-a sa Player-om
        textExit.GetComponent<Text>().enabled = true;
        textExitShadow.GetComponent<Text>().enabled = true;
        button.GetComponent<Button>().enabled = true;

        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
//1900.03



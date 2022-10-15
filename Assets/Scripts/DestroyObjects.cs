using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyObjects : MonoBehaviour
{
    public GameObject player;
    private float x;
    //public float distanceRender;
    public GameObject ScoreCounter;
    private Text ScoreText;
    public GameObject ScoreCounter2;
    private Text ScoreText2;
    public int value = 0; //bilo je 100
    private bool passed;
    private SpriteRenderer carRenderer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        ScoreCounter = GameObject.Find("Score");        
        ScoreCounter2 = GameObject.Find("ScoreShadow");
        ScoreText = ScoreCounter.GetComponent<Text>();
        ScoreText2 = ScoreCounter2.GetComponent<Text>();
        passed=false;
        carRenderer = gameObject.GetComponent<SpriteRenderer>();
        //(carRenderer = gameObject.GetComponent<SpriteRenderer>()).enabled = false;
        //Debug.Log("Rendered disabled at start: " + carRenderer.enabled.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        x = transform.position.x;
        if (x - player.transform.position.x < 25f/*distanceRender*/)
            carRenderer.enabled = true;
        /*else*/ if (player.transform.position.x - x > 4.5f && passed==false){
            ScoreText.text = ScoreText.text.Replace(ScoreText.text, (int.Parse(ScoreText.text) + value).ToString());
            ScoreText.SetAllDirty();
            ScoreText2.text = ScoreText2.text.Replace(ScoreText2.text, (int.Parse(ScoreText2.text) + value).ToString());
            ScoreText2.SetAllDirty();
            passed=true;
        }
        if (player.transform.position.x - x > 15 )
            gameObject.SetActive(false);//GameObject.DestroyImmediate(gameObject);
    }
}

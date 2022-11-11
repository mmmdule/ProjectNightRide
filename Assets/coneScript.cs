using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coneScript : MonoBehaviour
{
    private Collider2D objectCollider;
    private Collider2D playerCollider;
    public GameObject ScoreCounter;
    private Text ScoreText;
    public GameObject ScoreCounter2, player;
    private Text ScoreText2;
    public int value = 1;
    private float x;
    private bool once=false;
    private SpriteRenderer coneRenderer;

    //za statistiku
    private EndOfLevel EndTrigger;
    //za statistiku
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        coneRenderer = gameObject.GetComponent<SpriteRenderer>();

        //za statistiku
        EndTrigger = GameObject.Find("EndOfLevelTrigger").GetComponent<EndOfLevel>();
        //za statistiku
    }

    // Update is called once per frame
    void Update()
    {

        x = gameObject.transform.position.x;
        if (x - player.transform.position.x < 25f/*distanceRender*/)
            coneRenderer.enabled = true;
        if (player.transform.position.x - x > 15f)            
            GameObject.Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player" && !once){

            //za statistiku
            EndTrigger.ConesArePerfect = false;
            //za statistiku

            once = true;
            ScoreCounter = GameObject.Find("Score");        
            ScoreCounter2 = GameObject.Find("ScoreShadow");
            ScoreText2 = ScoreCounter2.GetComponent<Text>();
            ScoreText = ScoreCounter.GetComponent<Text>(); 

            ScoreText.text = ScoreText.text.Replace(ScoreText.text, (int.Parse(ScoreText.text) - 50).ToString());
            ScoreText.SetAllDirty();
            ScoreText2.text = ScoreText2.text.Replace(ScoreText2.text, (int.Parse(ScoreText2.text) - 50).ToString());
            ScoreText2.SetAllDirty();
            //Debug.Log("-50 by " + gameObject.name);
            GameObject.Destroy(gameObject);//Immediate(gameObject);
        }
    }
}
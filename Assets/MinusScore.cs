using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinusScore : MonoBehaviour
{
    public GameObject ScoreCounter;
    private Text ScoreText;
    private Color32 boja,bojaOG;
    // Start is called before the first frame update
    void Start()
    {
        ScoreCounter = GameObject.Find("Score");
        ScoreText = ScoreCounter.GetComponent<Text>();
        bojaOG = ScoreText.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(int.Parse(ScoreText.text)<0)
            ScoreText.color = Color.red;
        else
            ScoreText.color = bojaOG;
    }
}

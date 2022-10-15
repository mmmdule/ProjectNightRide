using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinGameOver : MonoBehaviour
{
    private GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = GameObject.Find("GameOverCanvas");
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver.GetComponent<Canvas>().enabled==true)
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        else
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}

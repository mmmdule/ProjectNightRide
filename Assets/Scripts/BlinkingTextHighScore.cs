using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingTextHighScore : MonoBehaviour
{
    public int Blink;
    private Color boja;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Text>().color=Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if(Blink<90){
            Blink++;
        }
        else{
            Blink=0;
            if(gameObject.GetComponent<Text>().color==Color.red)
                gameObject.GetComponent<Text>().color = Color.green;
            else
                gameObject.GetComponent<Text>().color=Color.red;
        }
    }
}

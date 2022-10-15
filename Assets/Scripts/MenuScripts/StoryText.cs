using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryText : MonoBehaviour
{
    private string Name;
    public int Level;
    public bool Move,Stay;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        Name = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("Level")!=Level)
            gameObject.SetActive(false);

        if(Stay==false){
            if(Move==true){
                if(transform.position.y<=-3.53f)
                    transform.position = new Vector3(transform.position.x, transform.position.y + 0.02f, transform.position.z);
            }
            else{
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.02f, transform.position.z);
                if(transform.position.y>10f)
                    gameObject.SetActive(false);
            }
        }
    }
}

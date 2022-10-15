using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unlock : MonoBehaviour
{
    public GameObject button;
    public string LevelName;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt(LevelName)>0){
            button.GetComponent<Button>().enabled = true;
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

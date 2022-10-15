using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public bool preLevel;
    public bool skip;
    public float WaitSeconds = 1f;
    public void ChangeScene(int SceneInt){
        StartCoroutine(FadeToNext());
        if(preLevel==true){
            //StartCoroutine(FadeToNext());
            SceneManager.LoadScene(9);
            PlayerPrefs.SetInt("Level" , SceneInt);
        }
        else if(skip==true){
            //StartCoroutine(FadeToNext());
            SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
        }
        else{
            //StartCoroutine(FadeToNext());
            SceneManager.LoadScene(SceneInt);
        }

        
    }
    public void LoadLevel(int Scene){
        StartCoroutine(FadeToNext());
        StartCoroutine(Coroutine(WaitSeconds));
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
        
        
    }
    public int Escape;
    void Update(){
        if (Escape==1 && Input.GetKeyDown("escape"))
            SceneManager.LoadScene(0);
    }

    IEnumerator Coroutine(float seconds)
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(seconds);
    }

    IEnumerator FadeToNext(){
        GameObject FadeSprite = GameObject.Find("FadeToNextSceneCover");
        FadeSprite.GetComponent<SpriteRenderer>().enabled = true;
        FadeSprite.GetComponent<fadeInSpriteTestScript>().enabled = true;
        FadeSprite.GetComponent<fadeAwaySpriteTestScript>().enabled = true;
        yield return new WaitForSeconds(FadeSprite.GetComponent<fadeInSpriteTestScript>().wait + FadeSprite.GetComponent<fadeAwaySpriteTestScript>().wait);
    }
}

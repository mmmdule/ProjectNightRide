using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class fadeInSpriteTestScript : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer Renderer;
    public float wait;
    public bool doFadeAway;
    Color color1;
    private bool done;
    public bool fadeColorBlack = false;
    IEnumerator Start()
    {
        done = false;
        if(!fadeColorBlack){
            color1 = new Color(1, 1, 1, 1);
        }
        else{
            color1 = new Color(0, 0, 0, 1);
        }
        Renderer = gameObject.GetComponent<SpriteRenderer>();
        yield return new WaitForSeconds(wait);
        Renderer.enabled = true;
        yield return StartCoroutine(FadeImage(doFadeAway));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator FadeImage(bool fadeAway)
    {
        if (!done)
        {
            // fade from opaque to transparent
            if (fadeAway)
            {
                // loop over 1 second backwards
                for (float i = 1; i >= 0; i -= Time.deltaTime)
                {
                    // set color with i as alpha
                    Renderer.color = new Color(1, 1, 1, i);
                    yield return new WaitForSeconds(0.0125f);//yield return null;
                }
                Renderer.enabled = false;
                done = true;
            }
            // fade from transparent to opaque
            else
            {
                // loop over 1 second
                for (float i = 0; i <= 1; i += Time.deltaTime)
                {
                    color1.a = i;
                    // set color with i as alpha
                    Renderer.color = color1;
                    Debug.Log("doing stuff");
                    yield return new WaitForSeconds(0.0125f);//yield return null;
                }
            }
            done = true;
        }

    }
}

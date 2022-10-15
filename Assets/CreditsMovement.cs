using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMovement : MonoBehaviour
{
    private string Name;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        Name = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        if(Name=="Image3"){
            if(transform.position.y<-0.1f)
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.027f, transform.position.z);
        }
        else
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.027f, transform.position.z);

        if(transform.position.y>45)
            Destroy(gameObject);
    }
}

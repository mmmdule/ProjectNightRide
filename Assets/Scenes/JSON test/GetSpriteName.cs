using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSpriteName : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.GetComponent<SpriteRenderer>().sprite.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

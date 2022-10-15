using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMovementNPC : MonoBehaviour
{
    private GameObject[] cars;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    

    void OnCollisionEnter2D(Collision2D collision)
    {
        cars = GameObject.FindGameObjectsWithTag("Obstacle");
        for(int i=0; i<cars.Length; i++)
            cars[i].GetComponent<NPCmovement>().enabled = true;
        gameObject.SetActive(false);
    }
}

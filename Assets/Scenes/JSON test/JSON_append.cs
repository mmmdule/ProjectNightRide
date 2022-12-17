using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JSON_append : MonoBehaviour
{
    private ZastavaData zastavaDataForJSON;
    private GameObject saveHandler;
    private JSON_save saveScript;
    // Start is called before the first frame update
    void Start()
    {
        saveHandler = GameObject.Find("ObjectLoader");
        saveScript = saveHandler.GetComponent<JSON_save>();

        zastavaDataForJSON = new ZastavaData(gameObject.transform.position, gameObject.GetComponent<SpriteRenderer>().sprite.name);
        
        //Debug.Log(JsonUtility.ToJson(zastavaDataForJSON).ToString());
        
        saveScript.saveString += JsonUtility.ToJson(zastavaDataForJSON);

    }

    public class ZastavaData{
        //public Transform transformData;
        public Vector3 position;
        public string spriteName;

        public ZastavaData(Vector3 position, string spriteName)
        {
            this.position = position;
            this.spriteName = spriteName;
        }
    }
}
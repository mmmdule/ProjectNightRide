using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSON_load : MonoBehaviour
{
    public string loadString = "";
    public ZastavaData zastavaDataTmp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

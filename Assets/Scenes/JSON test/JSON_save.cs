using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSON_save : MonoBehaviour
{
    public string saveString = "";
    public string LevelName;
    
    private ConeListClass coneListClassObject = new ConeListClass();
    private ZastavaListClass zastavaListClassObject = new ZastavaListClass(); //sa ovolikim imenom ko Javu da pisem
    public string dataPath;
    public bool save, cars = true, cones, saveCones;
    // Start is called before the first frame update
    void Start()
    {
        dataPath = Application.dataPath;

        if(cars){
            if(save)
                Save(zastavaListClassObject);
            else
                Load();
        }
        
        if(cones){
            if(saveCones)
                SaveCones(coneListClassObject);//metoda za cuvanje cunjeva
            else
                LoadCones();//metoda za ucitavanje cunjeva
        }


        //Save(zastavaListClassObject);

    }

    void Save(ZastavaListClass zastavaListClassObject){
        GameObject[] array = GameObject.FindGameObjectsWithTag("Obstacle");

        ZastavaData tmp = new ZastavaData(Vector3.zero, "", 0);
        for(int i = 0; i < array.Length; i++){
            
            zastavaListClassObject.zastavaDataList.Add(new ZastavaData(array[i].transform.position,array[i].GetComponent<SpriteRenderer>().sprite.name, array[i].GetComponent<SpriteRenderer>().sortingOrder));
        }
        /*
        foreach(GameObject gameObj in array){
            tmp.position = gameObj.transform.position;
            tmp.spriteName = gameObj.GetComponent<SpriteRenderer>().sprite.name;
            zastavaListClassObject.zastavaDataList.Add(tmp);
            //Debug.Log("Added gameobject to list.");
        }
        */
        saveString = JsonUtility.ToJson(zastavaListClassObject);

        if(LevelName!=""){
            File.WriteAllText(Application.dataPath + LevelName + ".json", saveString);
            Debug.Log("JSON saved.");
        }
    }

    

    public GameObject zastavaPrefabBlue, zastavaPrefabGreen, zastavaPrefabRed, zastavaPrefabOrange, zastavaPrefabBlack; 

    
    void Load(){
        var jsonString = Resources.Load<TextAsset>("JSON/Assets" + LevelName);//File.ReadAllText(dataPath + LevelName + ".json");
        
        Quaternion quaternion = Quaternion.identity;//new Quaternion(0f,0f,-1.511f,0f);
        GameObject tmp = new GameObject();
        zastavaListClassObject = JsonUtility.FromJson<ZastavaListClass>(jsonString.text);
        Vector3 vectorRotate = Vector3.zero;
        vectorRotate.z = -1.511f;
        foreach(ZastavaData zastavaData in zastavaListClassObject.zastavaDataList){
            switch(zastavaData.spriteName){
                case "Zastava red 1":
                    tmp = Instantiate(zastavaPrefabRed, zastavaData.position, zastavaPrefabRed.transform.rotation);
                    tmp.GetComponent<SpriteRenderer>().sortingOrder = zastavaData.orderInLayer;

                    break;
                case "Zastava black 1":
                    tmp = Instantiate(zastavaPrefabBlack, zastavaData.position, zastavaPrefabRed.transform.rotation);
                    tmp.GetComponent<SpriteRenderer>().sortingOrder = zastavaData.orderInLayer;

                    break;
                case "Zastava green 1":
                    tmp = Instantiate(zastavaPrefabGreen, zastavaData.position, zastavaPrefabRed.transform.rotation);
                    tmp.GetComponent<SpriteRenderer>().sortingOrder = zastavaData.orderInLayer;

                    break;
                case "Zastava blue 1":
                    tmp = Instantiate(zastavaPrefabBlue, zastavaData.position, zastavaPrefabRed.transform.rotation);
                    tmp.GetComponent<SpriteRenderer>().sortingOrder = zastavaData.orderInLayer;

                    break;
                case "Zastava orange 1":
                    tmp = Instantiate(zastavaPrefabOrange, zastavaData.position, zastavaPrefabRed.transform.rotation);
                    tmp.GetComponent<SpriteRenderer>().sortingOrder = zastavaData.orderInLayer;

                    break;
            }
        }
        Debug.Log("Loaded all obstacle gameObjects.");
        

        /*
        GameObject tmp = new GameObject();
        amountToPool = zastavaListClassObject.zastavaDataList.Count;
        for(int i = 0; i < amountToPool; i++){
            switch(zastavaListClassObject.zastavaDataList[i].spriteName){
                case "Zastava red 1":
                    tmp = Instantiate(zastavaPrefabRed, zastavaListClassObject.zastavaDataList[i].position, Quaternion.identity);
                    break;
                case "Zastava black 1":
                    tmp = Instantiate(zastavaPrefabBlack, zastavaListClassObject.zastavaDataList[i].position, Quaternion.identity);
                    break;
                case "Zastava green 1":
                    tmp = Instantiate(zastavaPrefabGreen, zastavaListClassObject.zastavaDataList[i].position, Quaternion.identity);
                    break;
                case "Zastava blue 1":
                    tmp = Instantiate(zastavaPrefabBlue, zastavaListClassObject.zastavaDataList[i].position, Quaternion.identity);
                    break;
                case "Zastava orange 1":
                    tmp = Instantiate(zastavaPrefabOrange, zastavaListClassObject.zastavaDataList[i].position, Quaternion.identity);
                    break;
            }
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }

*/
    }

    public GameObject conePrefab;
    void LoadCones(){
        var jsonString = Resources.Load<TextAsset>("JSON/Assets" + LevelName + "Cones");//File.ReadAllText(dataPath + LevelName + ".json");
        
        Quaternion quaternion = Quaternion.identity;//new Quaternion(0f,0f,-1.511f,0f);
        GameObject tmp = new GameObject();
        coneListClassObject = JsonUtility.FromJson<ConeListClass>(jsonString.text);
        Vector3 vectorRotate = Vector3.zero;
        vectorRotate.z = -38.336f;
        foreach(ConeData coneData in coneListClassObject.coneDataList){
            tmp = Instantiate(conePrefab, coneData.position, conePrefab.transform.rotation);
            tmp.GetComponent<SpriteRenderer>().sortingOrder = coneData.orderInLayer;
        }
        Debug.Log("Loaded all cone gameObjects.");
    }

    void SaveCones(ConeListClass coneListClassObject){
        GameObject[] array = GameObject.FindGameObjectsWithTag("Cone");

        ConeData tmp = new ConeData(Vector3.zero, 0);
        for(int i = 0; i < array.Length; i++){
            tmp = new ConeData(array[i].transform.position, array[i].GetComponent<SpriteRenderer>().sortingOrder);

            coneListClassObject.coneDataList.Add(tmp);
            //coneListClassObject.coneDataList.Add(new ConeData(array[i].transform.position, array[i].GetComponent<SpriteRenderer>().sortingOrder));
        }
        
        saveString = JsonUtility.ToJson(coneListClassObject);

        if(LevelName!=""){
            File.WriteAllText(Application.dataPath + LevelName + "Cones.json", saveString);
            Debug.Log("Cone JSON saved.");
        }
    }


    [Serializable]
    public class ZastavaListClass{
        public List<ZastavaData> zastavaDataList = new List<ZastavaData>();
    }

    [Serializable]
    public class ZastavaData{
        //public Transform transformData;
        public Vector3 position;
        public string spriteName;
        public int orderInLayer;
        public float rotationY = -1.511f;
        public ZastavaData(Vector3 position, string spriteName, int orderInLayer)
        {
            this.position = position;
            this.spriteName = spriteName;
            this.orderInLayer = orderInLayer;
        }
    }



    [Serializable]
    public class ConeListClass{
        public List<ConeData> coneDataList = new List<ConeData>();
    }

    [Serializable]
    public class ConeData{
        //public Transform transformData;
        public Vector3 position;
        public int orderInLayer;
        public float rotationY = -38.336f;

        public ConeData(Vector3 position, int orderInLayer)
        {
            this.position = position;
            this.orderInLayer = orderInLayer;
        }
    }
}





        /*
        foreach(ZastavaData zastavaData in zastavaListClassObject.zastavaDataList){
            switch(zastavaData.spriteName){
                case "Zastava red 1":
                    Instantiate(zastavaPrefabRed, zastavaData.position, Quaternion.identity);
                    break;
                case "Zastava black 1":
                    Instantiate(zastavaPrefabBlack, zastavaData.position, Quaternion.identity);
                    break;
                case "Zastava green 1":
                    Instantiate(zastavaPrefabGreen, zastavaData.position, Quaternion.identity);
                    break;
                case "Zastava blue 1":
                    Instantiate(zastavaPrefabBlue, zastavaData.position, Quaternion.identity);
                    break;
                case "Zastava orange 1":
                    Instantiate(zastavaPrefabOrange, zastavaData.position, Quaternion.identity);
                    break;
            }
        }
        Debug.Log("Loaded all obstacle gameObjects.");
        */
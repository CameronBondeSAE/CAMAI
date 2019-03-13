using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ObjectLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Makeobject()
    {
        JsonObject myobject = new JsonObject();
        myobject.range = 1;
        myobject.amount = 2;
        myobject.objectname = "tooie";
    }

    public string PackSetting<T>(T item)
    {
        return JsonUtility.ToJson(item,true);
    }

    public T UnpackSetting<T>(string item)
    {
        return JsonUtility.FromJson<T>(item);
    }

    public void SaveFile(string item, string itemname)
    {
        System.IO.File.WriteAllText(Path.Combine(Application.persistentDataPath, itemname+".json"),item);
    }

    public string LoadFile(string itemname)
    {
        return System.IO.File.ReadAllText(Path.Combine(Application.persistentDataPath, itemname+".json"));
    }
    
}

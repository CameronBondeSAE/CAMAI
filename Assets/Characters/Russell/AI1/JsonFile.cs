using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonFile : MonoBehaviour
{
    private Health myHealth;
    private Energy myEnergy;
    private TestJson testingJson;
    [SerializeField]
    public class TestJson
    {
        public float maxHealth;
        public float maxEnergy;
    }
    // Start is called before the first frame update
    private void Awake()
    {
        myHealth = GetComponent<Health>();
        myEnergy = GetComponent<Energy>();
        testingJson = new TestJson();
        testingJson.maxHealth = myHealth.maxAmount;
        testingJson.maxEnergy = myEnergy.MaxEnergy;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            OnSave();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            OnLoad();
        }
    }

    void OnSave()
    {
        string json = JsonUtility.ToJson(testingJson);
        Debug.Log("Json Saved" + json);
        File.WriteAllText(Path.Combine(Application.persistentDataPath, "test.json"),json);
    }

    void OnLoad()
    {
        string input = "";
        input = File.ReadAllText(Path.Combine(Application.persistentDataPath, "test.json"));
        testingJson = JsonUtility.FromJson<TestJson>(input);
        UpdateStats();
        Debug.Log("Loaded" + input);
    }

    void UpdateStats()
    {
        //myEnergy.MaxEnergy = testingJson.maxEnergy;
        myHealth.maxAmount = testingJson.maxHealth;
    }
}

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening.Plugins.Core.PathCore;
using Kennith;
using UnityEngine;

public class FileIO : MonoBehaviour
{

    private Kennith_Model myModel;
    private Health myHealth;
    private Energy myEnergy;

    [Serializable]
    public class ToSave
    {
        public string charName;
        public float health;
        public float energy;
    }

    private ToSave myDetails;
    public ToSave loadedDetails;
    
    private void Awake()
    {
        myModel = GetComponent<Kennith_Model>();
        myHealth = GetComponent<Health>();
        myEnergy = GetComponent<Energy>();
        
        myDetails = new ToSave();
        myDetails.charName = myModel.characterName;
        myDetails.health = myHealth.Amount;
        myDetails.energy = myEnergy.Amount;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Load();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Save();
        }
    }
    
    
    public void Save()
    {
        string json = JsonUtility.ToJson(myDetails);
        Debug.Log("SAVED " + json);

        File.WriteAllText(System.IO.Path.Combine(Application.persistentDataPath, "SavedDetails.json"), json);

    }
    
    
    public void Load()
    {
        string input = "";
        input = File.ReadAllText(System.IO.Path.Combine(Application.persistentDataPath, "SavedDetails.json"));
        loadedDetails = JsonUtility.FromJson<ToSave>(input);
        
        Debug.Log("LOADED " + input);
    }
    
}

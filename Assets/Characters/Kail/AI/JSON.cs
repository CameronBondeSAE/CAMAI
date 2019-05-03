using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Kail
{

    public class JSON : MonoBehaviour
    {
        //Varaible being saved
        private Health health;
        
        //where it gets saved to
        private SuckerYouController controller;

        private void Awake()
        {
            health = GetComponent<Health>();
            controller = GetComponent<SuckerYouController>();


        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S)) OnSave();
            if (Input.GetKeyDown(KeyCode.L)) OnLoad();
        }

        void OnSave()
        {
            //turn data into a string
            string json = JsonUtility.ToJson(health);
            //save it
            File.WriteAllText(Path.Combine(Application.persistentDataPath, "ai.json"), json);
            
        }

        void OnLoad()
        {
            //read save data into a string
            string save;
            save = File.ReadAllText(Path.Combine(Application.persistentDataPath, "ai.json"));
            //convert back
            health = JsonUtility.FromJson<Health>(save);
            //and set it
            controller.healthBase.maxAmount = health.maxAmount;

        }
    }
}
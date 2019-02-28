using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Michael
{
    [CustomEditor(typeof(Vestra_Model))]
    public class Vestra_Editor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
                        
            var vestra_Model = target as Vestra_Model;
                        
            if (GUILayout.Button("Flee Changes"))
            {
                //vestra_Model.GameObject.GetComponent(Health).Change(-90, vestra_Model.GameObject);
                //vestra_Model.CanS
            }
            if (GUILayout.Button("Roam Changes"))
            {
                Debug.Log("here");
            }
            if (GUILayout.Button("Magic Missle"))
            {
                Debug.Log("here");
            }
            if (GUILayout.Button("Comming Soon"))
            {
                Debug.Log("here");
            }
            if (GUILayout.Button("Comming Soon Too"))
            {
                Debug.Log("here");
            }    
            if (GUILayout.Button("Comming Soon Too"))
            {
                
            }           
            //GUI.Button();
        }    
    }
}
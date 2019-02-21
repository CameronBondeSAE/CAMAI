using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Russell
{
    [CustomEditor(typeof(Kyllarr_Model))]
    public class Kyllarr_ModelEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            Kyllarr_Model kyllarr_model = target as Kyllarr_Model;
        
            //GUILayout
            if (GUILayout.Button("TEST"))
            {
                Debug.Log("Testing");
            }
        }
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

namespace Kail
{

    [CustomEditor(typeof(MyGuyController))]
    
    public class InspectorMyGuy : Editor
    {
        public override void OnInspectorGUI()
        {
            MyGuyController myGuy = (MyGuyController)target;
            if (GUILayout.Button("Idle"))
            {
                myGuy.SetState(0);
            }
            if (GUILayout.Button("Attack"))
            {
                myGuy.SetState(1);
            }
            if (GUILayout.Button("Run Away"))
            {
                myGuy.SetState(2);
            }
            if (GUILayout.Button("Die now"))
            {
                myGuy.SetState(3);
            }
            
            base.OnInspectorGUI();
        }
    }
}
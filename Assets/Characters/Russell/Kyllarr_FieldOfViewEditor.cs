using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Russell
{
    [CustomEditor(typeof(FieldOfView))]
    public class Kyllarr_FieldOfViewEditor : Editor
    {
        // Start is called before the first frame update
        void OnSceneGUI()
        {
            FieldOfView fow = target as FieldOfView;
            Handles.color = Color.green;
            Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 360, fow.radius);
            Vector3 viewAngleA = fow.DirectionAngles(-fow.viewAngle / 2, false);
            Vector3 viewAngleB = fow.DirectionAngles(fow.viewAngle / 2, false);

            Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.radius);
            Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.radius);
            


        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            FieldOfView fow = target as FieldOfView;
            if (GUILayout.Button("Get Targets"))
            {
                fow.FindVisibleTargets();
            }
        }
        
    
        // Update is called once per frame
        void Update()
        {
            
        }
    }


}

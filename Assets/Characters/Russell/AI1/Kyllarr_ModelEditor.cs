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
            if (GUILayout.Button("Kill Move"))
            {
                kyllarr_model.DashAttack();
            }
            if (GUILayout.Button("Kill Me"))
            {
                kyllarr_model.Kyllarr_Dies();
            }
            if (GUILayout.Button("DECOY!"))
            {
                kyllarr_model.JustGotHurt();
            }

            if (GUILayout.Button("TestHover"))
            {
                kyllarr_model.ChangeState(kyllarr_model.hoverState);
            }
        }
    }

}


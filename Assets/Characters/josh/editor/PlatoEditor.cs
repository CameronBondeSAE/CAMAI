using UnityEngine;
using UnityEditor;

namespace Josh
{
    [CustomEditor(typeof(PlatoBehaviour))]
    public class PlatoEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            //DrawDefaultInspector();
            PlatoBehaviour mytarget = (PlatoBehaviour)target;
            if (GUILayout.Button("walk"))
            {
                mytarget.ChangeState(mytarget.gameObject.GetComponent<WalkState>());
            }
        }
    }
}

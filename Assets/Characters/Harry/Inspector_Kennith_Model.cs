using UnityEditor;
using UnityEngine;

namespace Kennith
{
    
    [CustomEditor(typeof(Kennith_Model))]
    public class Inspector_Kennith_Model : Editor
    {

        public override void OnInspectorGUI()
        {
            
            Kennith_Model model = (Kennith_Model)target;
            if(GUILayout.Button("Throw Spirit Bomb"))
            {
                model.ChangeState(model.spiritBombState);
            }
            
            if(GUILayout.Button("Go Idle"))
            {
                model.ChangeState(model.idleState);
            }
            
            if(GUILayout.Button("Move Around"))
            {
                model.ChangeState(model.moveState);
            }
            
            if(GUILayout.Button("FLEE"))
            {
                model.ChangeState(model.fleeState);
            }
            
            if(GUILayout.Button("Perish"))
            {
                model.ChangeState(model.deathState);
            }
            
            DrawDefaultInspector();
        }
        
    }
    
}


using UnityEditor;
using UnityEngine;

namespace Kennith
{
    public class InspectorWindow_Kennith_Model : EditorWindow
    {
       
        Kennith_Model model;
        
        [MenuItem("AI's/Kennith")]
        public static void ShowWindow()
        {
            GetWindow(typeof(InspectorWindow_Kennith_Model));
        }
        
        private void OnGUI()
        {

            if (Selection.activeGameObject == null)
            {
                GUILayout.Label("Select a Kennith-type AI to control");
                return;
            }
            
            model = Selection.activeGameObject.GetComponent<Kennith_Model>();

            if (model == null)
            {
                GUILayout.Label("Select a Kennith-type AI to control");
                return;
            }
            
            if(GUILayout.Button("Throw Spirit Bomb"))
            {
                if (model != null)
                {
                    if (!Application.isPlaying)
                    {
                        Debug.LogWarning("Editor must be playing for this button to function");
                    } else model.ChangeState(model.spiritBombState);
                }
                else
                {
                    Debug.LogError("Selected Object does not have required component");
                }
            }
            
            if(GUILayout.Button("Throw Hail Attack"))
            {
                if (model != null)
                {
                    if (!Application.isPlaying)
                    {
                        Debug.LogWarning("Editor must be playing for this button to function");
                    } else model.ChangeState(model.hailState);
                }
                else
                {
                    Debug.LogError("Selected Object does not have required component");
                }
            }
            
            if(GUILayout.Button("Go Idle"))
            {
                if (model != null)
                {
                    if (!Application.isPlaying)
                    {
                        Debug.LogWarning("Editor must be playing for this button to function");
                    } else model.ChangeState(model.idleState);
                }
                else
                {
                    Debug.LogError("Selected Object does not have required component");
                }
            }
            
            if(GUILayout.Button("Move Around"))
            {
                if (model != null)
                {
                    if (!Application.isPlaying)
                    {
                        Debug.LogWarning("Editor must be playing for this button to function");
                    } else model.ChangeState(model.moveState);
                }
                else
                {
                    Debug.LogError("Selected Object does not have required component");
                }
            }
            
            if(GUILayout.Button("FLEE"))
            {
                if (model != null)
                {
                    if (!Application.isPlaying)
                    {
                        Debug.LogWarning("Editor must be playing for this button to function");
                    } else model.ChangeState(model.fleeState);
                }
                else
                {
                    Debug.LogError("Selected Object does not have required component");
                }
            }
            
            if(GUILayout.Button("Perish"))
            {
                if (model != null)
                {
                    if (!Application.isPlaying)
                    {
                        Debug.LogWarning("Editor must be playing for this button to function");
                    } else model.ChangeState(model.deathState);
                }
                else
                {
                    Debug.LogError("Selected Object does not have required component");
                }
            }
            
        }
    }
}


using NodeCanvas.Tasks.Actions;
using UnityEngine;
using UnityEditor;

namespace Auriel
{
   public class AurielEditor : EditorWindow
   {
      private Auriel_Model auriel;

      [MenuItem("AI's/Auriel")]
      public static void ShowWindow()
      {
         GetWindow<AurielEditor>("Auriel States");
      }

      void OnGUI()
      {
         GUILayout.Label("Manually change Auriel's states (for testing).", EditorStyles.boldLabel);

         if (Selection.activeGameObject == null)
         {
            GUILayout.Label("Select an Auriel AI to use this editor");
         }

         auriel = Selection.activeGameObject.GetComponent<Auriel_Model>();

         if (auriel == null)
         {
            GUILayout.Label("Select an Auriel AI to use this editor");
         }
         
         if (GUILayout.Button("Movement State"))
         {
            if (auriel != null)
            {
               auriel.ChangeState(auriel.movementState);
               Debug.Log("Movement state activated");
            }
         }
      }
   }
}

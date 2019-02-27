using UnityEditor;
using UnityEngine;

// We're inheriting from "EditorWindow"
public class CamKillTester : EditorWindow
{
    // WHERE should this window be launched from? Which menu?
    [MenuItem("AI's/Cams Window")]
    public static void ShowWindow()
    {
        // Note the "CamEd" should be yours
        EditorWindow.GetWindow(typeof(CamKillTester));
    }
    
    private void OnGUI()
    {
        GUILayout.Label("Attempt to kill...");

        // Loop through all selected GameObjects
        foreach (Transform t in Selection.transforms)
        {
            // Simple button
            Health health = t.GetComponent<Health>();
            if (health != null)
            {
                if (GUILayout.Button(t.name))
                {
                    health.Amount = 0;
                }
            }
        }
    }
}
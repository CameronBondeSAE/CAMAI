using UnityEditor;
using UnityEngine;

// We're inheriting from "EditorWindow"
public class CamKillTester : EditorWindow
{
    // WHERE should this window be launched from? Which menu?
    [MenuItem("AI's/Attempt to kill...")]
    public static void ShowWindow()
    {
        // Note the "CamEd" should be yours
        EditorWindow.GetWindow(typeof(CamKillTester));
    }

    Health[] healths;


    private void Update()
    {
        Repaint();
    }

    private void OnGUI()
    {
        GUILayout.Label("All GO's with Health");

        healths = FindObjectsOfType<Health>();

        // Loop through all healths
        foreach (Health h in healths)
        {
            // Simple button
            if (GUILayout.Button(h.gameObject.name))
            {
                h.Amount = 0;
            }
        }

        GUILayout.Space(20);

        GUILayout.Label("Selected GO's with Health");

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
using UnityEditor;
using UnityEngine;

// We're inheriting from "EditorWindow"
public class CamEd : EditorWindow
{
	// WHERE should this window be launched from? Which menu?
	[MenuItem ("Window/Cams Window")]
	public static void ShowWindow () 
	{
		// Note the "CamEd" should be yours
		EditorWindow.GetWindow(typeof(CamEd));
	}
	
	private void OnGUI()
	{
		
		
		// Simple button
		if (GUILayout.Button("Press me"))
		{
			// We're about to mess with the transforms of the selection, so record their current values for UNDOing
			Undo.RecordObjects(Selection.transforms, "Selected GO's");

			// Loop through the selected object
			// You can grab their main GO/Transform etc also
			foreach (Transform t in Selection.transforms)
			{
				// eg Do something random to the selected gameobjects
				t.Rotate(0,Random.Range(-100,100),0);
			}
		}
	}
}

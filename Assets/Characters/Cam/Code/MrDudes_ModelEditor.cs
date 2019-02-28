using UnityEditor;
using UnityEngine;

namespace Cam
{

// This associates this editor with the component
[CustomEditor(typeof(MrDudes_Model))]
public class MrDudes_ModelEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		// Get a reference to the actual component this is assigned too
		// (Because we AREN'T that component, we're just part of the editor)
		MrDudes_Model mrDudesModel = target as MrDudes_Model;

		// This will layout the following 'immediate mode'
		// UI elements next to each other (If you leave this, they'll stack)
		GUILayout.BeginHorizontal();
		
		// Immediate mode stuff draws things AND returns any data from it
		if (GUILayout.Button("Get Big"))
		{
			mrDudesModel.GetBig();
		}
		if (GUILayout.Button("CAM!"))
		{
		}
		
		
		
		GUILayout.EndHorizontal();
		
		//EditorGUILayout.LabelField("(Above this object)");

	}
	
}

}

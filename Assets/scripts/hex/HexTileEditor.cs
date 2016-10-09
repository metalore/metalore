using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(HexTile))]

public class HexTileEditor : Editor
{
	//this adds a button to the inspector allowing 
	//testing of the tile height animation during playback only

	public override void OnInspectorGUI ()
	{
		DrawDefaultInspector ();

		HexTile hexTile = (HexTile)target;

		if (Application.isPlaying) {
			if (GUILayout.Button ("Update Hex Height")) {
				hexTile.UpdateHexHeight ();
			}
		}

	}
}


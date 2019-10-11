using System.Collections;
using System.Collections.Generic;
using Terrain_Generation;
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof (MapGenerator))]
public class MapGeneratorEditor : Editor
{
	public override void OnInspectorGUI(){
		MapGenerator mapGen = (MapGenerator) target;
		if (DrawDefaultInspector()){
			if (mapGen.autoUpdate){
				mapGen.DrawMapInEditor();
			}
		}
		if (GUILayout.Button("Generate")){
			mapGen.DrawMapInEditor();
		}
		if (GUILayout.Button("Clear")){
			mapGen.display.ClearMap();
			mapGen.display.UpdateData();
		}
	}
}
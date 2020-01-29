using System;
using UnityEngine;

namespace Terrain_Generation{
	public class MapGenerator : MonoBehaviour{

		public enum MapType{
			Blocks,
			Marching,
		}

		[SerializeField] private MapType mapType;
		[SerializeField] private int chunkSize = 64;
		[SerializeField] private float noiseScale = 1;
		[SerializeField] private float groundThreshold;
		[SerializeField] private bool inverse;
		public bool autoUpdate = false;
		public MapDisplay display = FindObjectOfType<MapDisplay>();
		
		public void DrawMapInEditor(){
			MapData mapData = GenerateMapData();

			switch (mapType){
				case MapType.Blocks:
					display.DrawBlocks (mapData, groundThreshold, inverse);
					break;
				case MapType.Marching:
					break;
				default:
					throw new ArgumentOutOfRangeException ();
			}
		}

		public MapData GenerateMapData (){
			float[,,] noiseMap = Noise.Generate3DNoiseMap (chunkSize, chunkSize, chunkSize, noiseScale);
			return new MapData(noiseMap);
		}
	}
	
	public class MapData{
		public float[,,] ValueMap;

		public MapData(float[,,] valueMap){
			this.ValueMap = valueMap;
		}
	}
}
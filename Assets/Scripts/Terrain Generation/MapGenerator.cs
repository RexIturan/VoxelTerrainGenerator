using UnityEngine;

namespace Terrain_Generation{
	public class MapGenerator : MonoBehaviour{

		[SerializeField] private int chunkSize = 64;
		[SerializeField] private float noiseScale = 1;
		[SerializeField] private float groundThreshold;
		public bool autoUpdate = false;
		public MapDisplay display = FindObjectOfType<MapDisplay>();
		
		public void DrawMapInEditor(){
			MapData mapData = GenerateMapData();

			display.DrawPoints (mapData, groundThreshold);
		}

		public MapData GenerateMapData (){
			float[,,] noiseMap = Noise.Generate3DNoiseMap (chunkSize, chunkSize, chunkSize, noiseScale);
			return new MapData(noiseMap);
		}
	
	
	}
	
	public struct MapData{
		public float[,,] ValueMap;

		public MapData(float[,,] valueMap){
			this.ValueMap = valueMap;
		}
	}
}
using UnityEngine;

namespace Terrain_Generation{
	public static class Noise
	{
		public static float[,] GenerateNoiseMap (int mapWidth, int mapHeight) {
			float[,] noiseMap = new float[mapWidth, mapHeight];
			return noiseMap;
		}

		public static float[,,] Generate3DNoiseMap (int mapWidth, int mapHeight, int mapDepth, float scale) {
			float[,,] noiseMap = new float[mapWidth, mapHeight, mapDepth];

			for (int z = 0; z < mapDepth; z++){
				for (int y = 0; y < mapHeight; y++){
					for (int x = 0; x < mapWidth; x++){
						float sampleX = x / scale;
						float sampleY = y / scale;
						float sampleZ = z / scale;
						
						noiseMap[x, y, z] = PerlinNoise3D (sampleX, sampleY, sampleZ);
					}
				}
			}

			return noiseMap;
		}

		

		public static float PerlinNoise3D(float x, float y, float z){
			float ab = Mathf.PerlinNoise (x, y);
			float bc = Mathf.PerlinNoise (y, z);
			float ac = Mathf.PerlinNoise (x, z);

			float ba = Mathf.PerlinNoise (y, x);
			float cb = Mathf.PerlinNoise (z, y);
			float ca = Mathf.PerlinNoise (z, x);

			float abc = ab + bc + ac + ba + cb + ca;
			return abc / 6f;
		}
	}
}

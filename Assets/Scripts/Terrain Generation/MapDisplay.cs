using UnityEngine;

namespace Terrain_Generation{
	public class MapDisplay : MonoBehaviour{

		[SerializeField] private GameObject block;
		private Transform mapParent;
		
		public void DrawBlocks (MapData mapData, float groundThreshold, bool inverse){
			ClearMap ();
			UpdateData ();
			
			int mapDepth = mapData.ValueMap.GetLength (2);
			int mapHeight = mapData.ValueMap.GetLength (1);
			int mapWidth = mapData.ValueMap.GetLength (0);
			
			
			for (int z = 0; z < mapDepth; z++){
				for (int y = 0; y < mapHeight; y++){
					for (int x = 0; x < mapWidth; x++){
						if (inverse){
							if (mapData.ValueMap[x,y,z] >= groundThreshold){
								GameObject curBlock = Instantiate(block, new Vector3(x, y, z), Quaternion.identity, mapParent);
								//curBlock.transform.localScale *= -mapData.ValueMap[x, y, z];
								//curBlock.GetComponent<Renderer>().material.color.a -= mapData.ValueMap[x, y, z] * 5;
								
							}	
						}
						else{
							if (mapData.ValueMap[x,y,z] <= groundThreshold){
								GameObject curBlock = Instantiate(block, new Vector3(x, y, z), Quaternion.identity, mapParent);
								//curBlock.transform.localScale *= -mapData.ValueMap[x, y, z];
								//curBlock.GetComponent<Renderer>().material.color.a -= mapData.ValueMap[x, y, z] * 5;
							}	
						}
					}
				}
			}
		}

		public void UpdateData (){
			if (GameObject.Find("MapParent") != null){
				mapParent = GameObject.Find("MapParent").transform;	
			}
			if (mapParent == null){
				mapParent = new GameObject("MapParent").transform;
			}
		}
		
		public void ClearMap(){
			if (mapParent != null){
				DestroyImmediate(mapParent.gameObject);
			}
		}
	}
}
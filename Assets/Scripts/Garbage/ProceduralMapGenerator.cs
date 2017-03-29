/*
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProceduralMapGenerator : MonoBehaviour {

	private int currentX;
	private int minX = 0;
	private int maxX = 4;
	private List<int> topXs = new List<int>();
	private List<int> bottomXs = new List<int>();
	private int Bounds;
	private int Scale;
	private GameObject BasicWall;
	private GameObject BasicCorner;
	private GameObject BasicVertex;
	private GameObject BasicFloor;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 10; i ++) {
			currentX = Random.Range (minX,maxX);
			Object.Instantiate (BasicWall, new Vector3(i * 20, 0, currentX * 10), Quaternion.Euler(0, 0, 0));
			topXs.Add (currentX);
			minX = currentX - 2;
			maxX = currentX + 2;
			//Debug.Log (minX + ", " + maxX);
			if(minX < 0){
				minX = 0;
			}
			if(maxX > 4){
				maxX = 4;
			}
			//Debug.Log (minX + ", " + maxX);
		}
		for(int i = 0; i < 9; i ++){
			if (topXs [i] == topXs [i + 1]) {
				Object.Instantiate (BasicWall, new Vector3 ((i * 20) + 10, 0, topXs [i] * 10), Quaternion.Euler(0, 0, 0));
			} else if (topXs [i] < topXs [i + 1]) {
				Object.Instantiate (BasicVertex, new Vector3 ((i * 20) + 10, 0, topXs [i] * 10), Quaternion.Euler(0, 0, 0));
				Object.Instantiate (BasicCorner, new Vector3 ((i * 20) + 10, 0, topXs [i + 1] * 10), Quaternion.Euler(0, 270, 0));
				if(topXs[i] * 10 > topXs[i + 1] * 10 + 10 ){
					Object.Instantiate (BasicWall, new Vector3((i * 20) + 10,0,topXs[i] * 10 + 10), Quaternion.Euler(0, 270, 0));
				}
			} else if (topXs [i] > topXs [i + 1]) {
				Object.Instantiate (BasicCorner, new Vector3 ((i * 20) + 10, 0, topXs [i] * 10), Quaternion.Euler(0, 0, 0));
				Object.Instantiate (BasicVertex, new Vector3 ((i * 20) + 10, 0, topXs [i + 1] * 10), Quaternion.Euler(0, 90, 0));
				if(topXs[i] * 10 > topXs[i + 1] * 10 + 10 ){
					Object.Instantiate (BasicWall, new Vector3((i * 20) + 10,0,topXs[i] * 10 - 10), Quaternion.Euler(0, 90, 0));
				}
			} else {
				Debug.Log ("error");
			}
		}
		for (int i = 0; i < 10; i ++) {
			currentX = Random.Range (minX,maxX);
			Object.Instantiate (BasicWall, new Vector3(i * 20, 0, currentX * 10- 200), Quaternion.Euler(0, 180, 0));
			bottomXs.Add (currentX);
			minX = currentX - 2;
			maxX = currentX + 2;
			//Debug.Log (minX + ", " + maxX);
			if(minX < 0){
				minX = 0;
			}
			if(maxX > 4){
				maxX = 4;
			}
			//Debug.Log (minX + ", " + maxX);
		}
		for(int i = 0; i < 9; i ++){
			if (bottomXs [i] == bottomXs [i + 1]) {
				Object.Instantiate (BasicWall, new Vector3 ((i * 20) + 10, 0, bottomXs [i] * 10 - 200), Quaternion.Euler(0, 180, 0));
			} else if (bottomXs [i] < bottomXs [i + 1]) {
				Object.Instantiate (BasicCorner, new Vector3 ((i * 20) + 10, 0, bottomXs [i] * 10 - 200), Quaternion.Euler(0, 90, 0));
				Object.Instantiate (BasicVertex, new Vector3 ((i * 20) + 10, 0, bottomXs [i + 1] * 10 - 200), Quaternion.Euler(0, 180, 0));
				if(bottomXs[i] * 10 > bottomXs[i + 1] * 10 + 10 ){
					Object.Instantiate (BasicWall, new Vector3((i * 20) + 10,0,bottomXs[i] * 10 + 10 - 200), Quaternion.Euler(0, 90, 0));
				}
			} else if (bottomXs [i] > bottomXs [i + 1]) {
				Object.Instantiate (BasicVertex, new Vector3 ((i * 20) + 10, 0, bottomXs [i] * 10 - 200), Quaternion.Euler(0, 270, 0));
				Object.Instantiate (BasicCorner, new Vector3 ((i * 20) + 10, 0, bottomXs [i + 1] * 10 - 200), Quaternion.Euler(0, 180, 0));
				if(bottomXs[i] * 10 > bottomXs[i + 1] * 10 + 10 ){
					Object.Instantiate (BasicWall, new Vector3((i * 20) + 10,0,bottomXs[i] * 10 - 10 - 200), Quaternion.Euler(0, 270, 0));
				}
			} else {
				Debug.Log ("error");
			}
		}
		Object.Instantiate (BasicCorner, new Vector3(-10, 0, topXs[0] * 10), Quaternion.Euler(0,270,0));
		Object.Instantiate (BasicCorner, new Vector3(-10, 0, bottomXs[0] * 10 -200), Quaternion.Euler(0,180,0));
		Object.Instantiate (BasicCorner, new Vector3(190, 0, topXs[9] * 10), Quaternion.Euler(0,0,0));
		Object.Instantiate (BasicCorner, new Vector3(190, 0, bottomXs[9] * 10 -200), Quaternion.Euler(0,90,0));

		for(){
			
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetStuff(int bounds, int scale, GameObject wall, GameObject corner, GameObject vertex, GameObject floor){
		Bounds = bounds;
		Scale = scale;
		BasicWall = wall;
		BasicCorner = corner;
		BasicVertex = vertex;
		BasicFloor = floor;
		PlaceCorners ();
		PlaceTopX ();
	}

	private void PlaceCorners(){
		Object.Instantiate (BasicCorner, new Vector3 (0, 0, 0), Quaternion.Euler (0, 270, 0));
		Object.Instantiate (BasicCorner, new Vector3 (0, 0, Bounds), Quaternion.Euler (0, 180, 0));
		Object.Instantiate (BasicCorner, new Vector3 (Bounds, 0, 0), Quaternion.Euler (0, 0, 0));
		Object.Instantiate (BasicCorner, new Vector3 (Bounds, 0, Bounds), Quaternion.Euler (0, 90, 0));
	}

	private void PlaceTopX(){
		for(int i = 0; i < Bounds; i++){
			Object.Instantiate(BasicWall, new Vector3 (0, 0, 0), Quaternion.Euler (0, 0, 0));
		}
	}
}
*/
/*
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PTG3 : MonoBehaviour {
	
	private int lastValue = 0;
	private int currentValue = 0;
	private int difference = 0;
	private float dif = 0;
	private Vector2 slope;
	//private int minX = 0;
	//private int maxX = 1;

	private GameObject corner1, corner2, corner3, corner4;

	//bounds equals how many prefabs across you want multipliedd by the scale
	[SerializeField]
	private int bounds, scale;

	[SerializeField]
	private GameObject basicWall, basicCorner, basicVertex, basicFloor;

	// Use this for initialization
	void Start () {
		corner1 = Object.Instantiate(basicCorner, new Vector3(0,0,bounds), Quaternion.Euler(0,270,0)) as GameObject;
		placeTopXs (bounds);
		corner2 = Object.Instantiate(basicCorner, new Vector3 (bounds, 0, bounds + (currentValue * scale)), Quaternion.Euler(0, 0, 0)) as GameObject;
		currentValue = 0;
		placeTopYs (bounds);
		slope.y = currentValue;
		//corner3 = Object.Instantiate (basicCorner, new Vector3 (bounds + (currentValue * scale), 0, 0), Quaternion.Euler(0, 90, 0)) as GameObject;
		currentValue = 0;
		placeBottomYs (0);
		corner4 = Object.Instantiate(basicCorner, new Vector3(currentValue * -scale,0,0), Quaternion.Euler(0,180,0)) as GameObject;
		currentValue = 0;
		placeBottomXs (0);
		slope.x = currentValue;
		dif = slope.x / slope.y;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void DoValues(){
		lastValue = currentValue;
		int minX = currentValue - 1;
		int maxX = currentValue + 2;
		if (minX < 0) {
			minX = 0;
		}
		if (maxX > 5) {
			maxX = 5;
		}
		currentValue = Random.Range (minX, maxX);
		difference = currentValue - lastValue;
	}

	void placeTopXs(int boundary){
		for (float i = corner1.transform.position.x + scale; i < bounds; i += scale) {
			DoValues ();
			Vector3 temp1 = new Vector3 (i, 0, (currentValue * scale) + boundary);
			Vector3 temp2 = new Vector3 (i, 0, (lastValue * scale) + boundary);
			if(difference < 0){
				Object.Instantiate (basicVertex, temp1, Quaternion.Euler(0, 90, 0));
				Object.Instantiate (basicCorner, temp2, Quaternion.Euler(0, 0, 0));
			}else if(difference == 0){
				Object.Instantiate (basicWall, temp1, Quaternion.Euler(0, 0, 0));
			}else if(difference > 0){
				Object.Instantiate (basicCorner, temp1, Quaternion.Euler(0, 270, 0));
				Object.Instantiate (basicVertex, temp2, Quaternion.Euler(0, 0, 0));
			}
		}
	}

	void placeBottomXs(int boundary){
		for (float i = corner4.transform.position.x + scale; i < bounds; i += scale) {
			DoValues ();
			Vector3 temp1 = new Vector3 (i, 0, -currentValue * scale);
			Vector3 temp2 = new Vector3 (i, 0, -lastValue * scale);
			if(difference < 0){
				Object.Instantiate (basicVertex, temp1, Quaternion.Euler(0, 180, 0));
				Object.Instantiate (basicCorner, temp2, Quaternion.Euler(0, 90, 0));
			}else if(difference == 0){
				Object.Instantiate (basicWall, temp1, Quaternion.Euler(0, 180, 0));
			}else if(difference > 0){
				Object.Instantiate (basicCorner, temp1, Quaternion.Euler(0, 180, 0));
				Object.Instantiate (basicVertex, temp2, Quaternion.Euler(0, 270, 0));
			}
		}
	}

	void placeTopYs(int boundary){
		for (float i = corner2.transform.position.z - scale; i > 0; i -= scale) {
			DoValues ();
			Vector3 temp1 = new Vector3 ((currentValue * scale) + boundary, 0, i);
			Vector3 temp2 = new Vector3 ((lastValue * scale) + boundary, 0, i);
			if(difference < 0){
				Object.Instantiate (basicVertex, temp1, Quaternion.Euler(0, 180, 0));
				Object.Instantiate (basicCorner, temp2, Quaternion.Euler(0, 90, 0));
			}else if(difference == 0){
				Object.Instantiate (basicWall, temp1, Quaternion.Euler(0, 90, 0));
			}else if(difference > 0){
				Object.Instantiate (basicCorner, temp1, Quaternion.Euler(0, 0, 0));
				Object.Instantiate (basicVertex, temp2, Quaternion.Euler(0, 90, 0));
			}
		}
	}

	void placeBottomYs(int boundary){
		for (float i = corner1.transform.position.z - scale; i > 0; i -= scale) {
			DoValues ();
			Vector3 temp1 = new Vector3 ((-currentValue * scale) + boundary, 0, i);
			Vector3 temp2 = new Vector3 ((-lastValue * scale) + boundary, 0, i);
			if(difference < 0){
				Object.Instantiate (basicVertex, temp1, Quaternion.Euler(0, 270, 0));
				Object.Instantiate (basicCorner, temp2, Quaternion.Euler(0, 180, 0));
			}else if(difference == 0){
				Object.Instantiate (basicWall, temp1, Quaternion.Euler(0, 270, 0));
			}else if(difference > 0){
				Object.Instantiate (basicCorner, temp1, Quaternion.Euler(0, 270, 0));
				Object.Instantiate (basicVertex, temp2, Quaternion.Euler(0, 0, 0));
			}
		}
	}

	void closeTheGap(){
		float stuff = 0;
		for(float i = bounds + scale; i < slope.y + bounds; i += scale){
			stuff += dif;

			for(int o = 0; o > scale; stuff -= scale){
				
			}
		}
	}
}
*/
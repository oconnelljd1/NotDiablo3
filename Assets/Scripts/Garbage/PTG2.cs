/*
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PTG2 : MonoBehaviour {

	private int lastValue = 0;
	private int currentValue = 0;
	private int minX = 0;
	private int maxX = 2;

	private List<Vector3> positions= new List<Vector3>();

	//bounds equals how many prefabs across you want
	[SerializeField]
	private int bounds, scale;

	[SerializeField]
	private GameObject basicWall, basicCorner, basicVertex, basicFloor;

	// Use this for initialization
	void Start () {
		GameObject piece = Object.Instantiate (basicCorner, new Vector3(0,0,0), Quaternion.Euler (0, 270, 0)) as GameObject;
		positions.Add (piece.transform.position);
		for(int i = 0; i < bounds; i++){
			GameObject peice0 = Object.Instantiate (basicWall, new Vector3((i + 1) * 2 * bounds, 0, GetNextValue(0)), Quaternion.Euler(0,0,0)) as GameObject;
			positions.Add (piece.transform.position);
			switch(currentValue - lastValue + 2){
			case 0:
			case 1:
				GameObject piece1 = Object.Instantiate (basicCorner, new Vector3(), Quaternion.Euler(0,0,0)) as GameObject;
				GameObject piece2 = Object.Instantiate (basicCorner, new Vector3(), Quaternion.Euler(0,0,0)) as GameObject;
				positions.Add (piece.transform.position);
				positions.Add (piece.transform.position);
				if(currentValue - lastValue == -2){
					GameObject piece6 = Object.Instantiate (basicWall, new Vector3(), Quaternion.Euler(0,0,0)) as GameObject;
					positions.Add (piece.transform.position);
				}
				break;
			case 2:
				GameObject piece3 = Object.Instantiate (basicCorner, new Vector3(), Quaternion.Euler(0,0,0)) as GameObject;
				positions.Add (piece.transform.position);
				break;
			case 3:
			case 4:
				GameObject piece4 = Object.Instantiate (basicCorner, new Vector3(), Quaternion.Euler(0,0,0)) as GameObject;
				GameObject piece5 =Object.Instantiate (basicCorner, new Vector3(), Quaternion.Euler(0,0,0)) as GameObject;
				positions.Add (piece.transform.position);
				positions.Add (piece.transform.position);
				if (currentValue - lastValue == 2) {
					GameObject piece7 = Object.Instantiate (basicWall, new Vector3(), Quaternion.Euler(0,0,0)) as GameObject;
					positions.Add (piece.transform.position);
				}
				break;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	int GetNextValue(int boundary){
		lastValue = currentValue;
		int Value = Random.Range (minX, maxX);
		minX += Value;
		maxX += Value;
		if (minX < 0) {
			minX = 0;
		} else if (maxX > 4) {
			maxX = 4;
		}
		currentValue = Value + boundary;
		return currentValue;
	}
}
*/
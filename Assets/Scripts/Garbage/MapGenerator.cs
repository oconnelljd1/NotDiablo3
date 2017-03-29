using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {

	[SerializeField]
	private int height, width, scale;

	[SerializeField]
	public string seed;

	[SerializeField]
	public bool useRandomSeed;

	[SerializeField]
	[Range(0, 100)]
	private int randomFillPercent;

	[SerializeField]
	private GameObject floor, wall, edge, parallel, perpendicular, three, surrounded, corner;

	int[,] map;
	int changes = 1;

	void Start(){
		GenerateMap ();
	}
	///*
	void Update(){
		if(Input.GetMouseButtonDown(0)){
			GenerateMap ();
		}
	}
	//*/
	private void GenerateMap(){
		map = new int[width, height];
		RandomFillMap ();

		while (changes > 0) {
			changes = 0;
			SmoothMap ();
		}
		changes = 1;

		CheckWalls ();
		//TreeManager.instance.
	}

	void RandomFillMap(){
		if(useRandomSeed){
			seed = Time.time.ToString ();
		}
		System.Random pseudoRandom = new System.Random (seed.GetHashCode ());
		for (int i = 0; i < width; i++) {
			for (int o = 0; o < height; o++) {
				if (i == 0 || i == width - 1 || o == 0 || o == height - 1) {
					map [i, o] = 1;
				} else {
					float valueX = ((320 * i * i) / (width * width)) - ((320 * i) / width) + 90;
					float valueY = ((320 * o * o) / (height * height)) - ((320 * o) / height) + 90;
					if(valueX > valueY){
						map [i, o] = (pseudoRandom.Next (0, 100) < valueX) ? 1 : 0;
					}else{
						map [i, o] = (pseudoRandom.Next (0, 100) < valueY) ? 1 : 0;
					}

				}
			}
		}
	}

	void SmoothMap(){
		//Debug.Log ("smoothing");
		for(int i = 0; i < width; i++){
			for (int o = 0; o < height; o++) {
				int neighborWallTiles = GetSurroundingWallCount (i, o);

				if (neighborWallTiles > 4) {
					if (map [i, o] != 1) {
						changes++;
					}
					map [i, o] = 1;
				} else if(neighborWallTiles < 4) {
					if (map [i, o] != 0) {
						changes++;
					}
					map [i, o] = 0;
				}
			}
		}
	}

	int GetSurroundingWallCount(int gridX, int gridY){
		int WallCount = 0;
		for(int i = gridX - 1; i <= gridX +1; i++){
			for(int o = gridY - 1; o <= gridY +1; o++){
				if(i >= 0 && i < width && o >= 0 && o < height){
					if(i != gridX || o != gridY){
						WallCount += map [i, o];
					}
				}else{
					WallCount++;
				}
			}
		}
		return WallCount;
	}

	void CheckWalls(){
		for (int i = 0; i < width; i++) {
			for (int o = 0; o < height; o++) {
				if (map [i, o] == 1) {
					//if (i > 0 && i < width - 1 && o > 0 && o < height - 1) {
						PickWall (i, o);
					//} else {
					//	ComplicatedPickWall (i, o);
					//}
				} else {
					Object.Instantiate(floor, new Vector3(i * scale, 0, o * scale), Quaternion.Euler(0,0,0));
				}
			}
		}
	}

	void PickWall (int i, int o){
		int myCase = 0;
		///*
		for (int e = 0; e < 4; e++) {
			int checkX = Mathf.RoundToInt(Mathf.Cos (e * 90 * Mathf.Deg2Rad)) + i;
			int checkY = Mathf.RoundToInt(Mathf.Sin (e * 90 * Mathf.Deg2Rad)) + o;
			//Debug.Log (Mathf.Sin (e * 90 * Mathf.Deg2Rad));
			//Debug.Log (checkX + ", " + checkY);
			///*
			if (checkX < 0 || checkX == width || checkY < 0 || checkY == height) {
				myCase += Mathf.RoundToInt (Mathf.Pow (10, e));
			} else if (map [checkX, checkY] == 1) {
				myCase += Mathf.RoundToInt (Mathf.Pow (10, e));
			}
			//*/
			//if (map [Mathf.FloorToInt(Mathf.Cos (e * 90)) + i, Mathf.FloorToInt(Mathf.Sin (e * 90)) + o] == 0) {
			//myCase += Mathf.RoundToInt(Mathf.Pow (10, e)) * map [Mathf.RoundToInt(Mathf.Cos (e * 90 * Mathf.Deg2Rad) * Mathf.Rad2Deg) + i, Mathf.RoundToInt(Mathf.Sin (e * 90 * Mathf.Deg2Rad) * Mathf.Rad2Deg) + o];
				//Debug.Log(Mathf.Cos (e * 90) + ", " + Mathf.Sin (e * 90));
			//}
		}
		//*/
		/*
		if(map[i + 1, o] == 1){
			myCase += 1;
		}
		if(map[i,o - 1] == 1){
			myCase += 10;
		}
		if(map[i-1,o] == 1){
			myCase +=100;
		}
		if(map[i ,o+1] == 1){
			myCase += 1000;
		}
		*/
		//Debug.Log (myCase);
		InstantiateWall (i, o, myCase);
	}

	void InstantiateWall(int i, int o, int myCase){
		switch (myCase) {
		case 0000:
			Object.Instantiate (surrounded, new Vector3 (i * scale, 0, o * scale), Quaternion.Euler (0, 0, 0));
			break;
		case 0001:
			Object.Instantiate (three, new Vector3 (i * scale, 0, o * scale), Quaternion.Euler (0, 0, 0));
			break;
		case 0010:
			Object.Instantiate (three, new Vector3 (i * scale, 0, o * scale), Quaternion.Euler (0, 0, 0));
			break;
		case 0011:
			if(i - 1 > -1 && o - 1 > -1){
				if (map [i - 1, o - 1] == 0) {
					Object.Instantiate (corner, new Vector3 (i * scale, 0, o * scale), Quaternion.Euler (0, 180, 0));
				} else {
					Object.Instantiate (perpendicular, new Vector3 (i * scale, 0, o * scale), Quaternion.Euler (0, 270, 0));
				}
			}
			break;
		case 0100:
			Object.Instantiate (three, new Vector3 (i * scale, 0, o * scale), Quaternion.Euler (0, 0, 0));
			break;
		case 0101:
			Object.Instantiate (parallel, new Vector3 (i * scale, 0, o * scale), Quaternion.Euler (0, 0, 0));
			break;
		case 0110:
			if (i + 1 < width && o -1  > -1) {
				if (map [i + 1, o - 1] == 0) {
					Object.Instantiate (corner, new Vector3 (i * scale, 0, o * scale), Quaternion.Euler (0, 90, 0));
				} else {
					Object.Instantiate (perpendicular, new Vector3 (i * scale, 0, o * scale), Quaternion.Euler (0, 180, 0));
				}
			}
			break;
		case 0111:
			Object.Instantiate (edge, new Vector3 (i * scale, 0, o * scale), Quaternion.Euler (0, 270, 0));
			break;
		case 1000:
			Object.Instantiate (three, new Vector3 (i * scale, 0, o * scale), Quaternion.Euler (0, 0, 0));
			break;
		case 1001:
			if (i -1 > -1 && o + 1  < height) {
				if (map [i - 1, o + 1] == 0) {
					Object.Instantiate (corner, new Vector3 (i * scale, 0, o * scale), Quaternion.Euler (0, 270, 0));
				} else {
					Object.Instantiate (perpendicular, new Vector3 (i * scale, 0, o * scale), Quaternion.Euler (0, 0, 0));
				}
			}
			break;
		case 1010:
			Object.Instantiate (parallel, new Vector3 (i * scale, 0, o * scale), Quaternion.Euler (0, 0, 0));
			break;
		case 1011:
			Object.Instantiate (edge, new Vector3 (i * scale, 0, o * scale), Quaternion.Euler (0, 0, 0));
			break;
		case 1100:
			if (i + 1 < width && o + 1  < height) {
				if (map [i + 1, o + 1] == 0) {
					Object.Instantiate (corner, new Vector3 (i * scale, 0, o * scale), Quaternion.Euler (0, 0, 0));
				} else {
					Object.Instantiate (perpendicular, new Vector3 (i * scale, 0, o * scale), Quaternion.Euler (0, 90, 0));
				}
			}
			break;
		case 1101:
			Object.Instantiate (edge, new Vector3 (i * scale, 0, o * scale), Quaternion.Euler (0, 90, 0));
			break;
		case 1110:
			Object.Instantiate (edge, new Vector3 (i * scale, 0, o * scale), Quaternion.Euler (0, 180, 0));
			break;
		case 1111:
			//Object.Instantiate (basicWall, new Vector3 (i * scale, 0, o * scale), Quaternion.Euler (0, 0, 0));
			///*
			bool stop = false;
			for(int e = -1; e < 2; e +=2){
				for(int a = -1; a < 2; a +=2){
					if(i + e > -1 && i + e < width && o + a > -1 && o + a < height){
						if (map [i + e, o + a] == 0) {
							Object.Instantiate (wall, new Vector3 (i * scale, 0, o * scale), Quaternion.Euler (0, 0, 0));
							stop = true;
						}
					}
				}
				if (stop) {
					break;
				}
			}
			//*/
			break;
		default:
			Debug.Log ("error");
			break;
		}
	}
	/*
	void OnDrawGizmos(){
		if (map != null) {
			for(int i = 0; i < width; i++){
				for (int o = 0; o < height; o++) {
					Gizmos.color = (map [i, o] == 1)? Color.black:Color.white;
					Vector3 pos = new Vector3(-width/2 + i + 0.5f, 0, -height/2 + o+ 0.5f);
					Gizmos.DrawCube(pos, Vector3.one);
				}
			}
		}
	}
	*/

}

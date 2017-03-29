/*
using UnityEngine;
using System.Collections;

public class AreaManager : MonoBehaviour {

	private ProceduralMapGenerator PMG;

	//bounds is already modified by the scale. if you want 10 units by 10 units, and each unit is 10 units, bounds = 100; trust me, you understood this when you wrote it.
	[SerializeField]
	private int bounds;

	[SerializeField]
	private int scale;

	[SerializeField]
	private GameObject BasicWall;

	[SerializeField]
	private GameObject BasicCorner;

	[SerializeField]
	private GameObject BasicVertex;

	[SerializeField]
	private GameObject BasicFloor;

	// Use this for initialization
	void Start () {
		PMG.SetStuff (bounds, scale, BasicWall, BasicCorner, BasicVertex, BasicFloor);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
*/
using UnityEngine;
using System.Collections;

public class TreeManager : MonoBehaviour {

	public static TreeManager instance;

	[SerializeField]private Mesh[] treeMeshs;
	private GameObject[] myTrees;

	// Use this for initialization
	void Awake () {
		if (instance) {
			Object.Destroy (gameObject);
		} else {
			instance = this;
		}
	}

	void Start(){
		myTrees = GameObject.FindGameObjectsWithTag ("Tree");
		Debug.Log ("myTrees length = " + myTrees.Length);
		foreach(GameObject tree in myTrees){
			Mesh myMesh = treeMeshs[Random.Range (0, treeMeshs.Length)];
			GetComponent<MeshFilter> ().mesh = myMesh;
			GetComponent<MeshCollider>().sharedMesh = myMesh;
		}
	}
}

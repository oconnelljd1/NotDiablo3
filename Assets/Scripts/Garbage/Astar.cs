using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Astar : MonoBehaviour {

	private Node StartNode;
	private Node EndNode;
	private Node[,] grid;
	private float nodeRadius = 0.5f;
	private int nodeDiameter = 1;
	private int gridSizeX, gridSizeY;
	private List<Node> path = new List<Node>();
	[SerializeField] private Vector2 gridWorldSize;
	[SerializeField] private LayerMask unwalkableMask;
	[SerializeField]private GameObject target;
	[SerializeField]private GameObject start;

	// Use this for initialization
	void Start () {
		gridSizeX = Mathf.FloorToInt (gridWorldSize.x / nodeDiameter);
		gridSizeY = Mathf.FloorToInt (gridWorldSize.y / nodeDiameter);
		CreateGrid ();
		//path = GetComponent<PathfinderSRD> ().GetPath ();
	}

	void OnDrawGizmos(){
		Gizmos.DrawWireCube (new Vector3(gridWorldSize.x / 2, 0.5f, gridWorldSize.y / 2), new Vector3(gridWorldSize.x, 1, gridWorldSize.y));
		if(grid != null){
			foreach (Node n in grid) {
				Gizmos.color = (n.GetWalkable())?Color.green:Color.red;
				if (path != null) {
					if (path.Contains (n)) {
						Gizmos.color = Color.black;
					}
				}
				if(n == StartNode){
					Gizmos.color = Color.blue;
				}else if(n == EndNode){
					Gizmos.color = Color.yellow;
				}
				Gizmos.DrawCube (n.GetWorldPos(), Vector3.one * nodeDiameter);
			}
		}
	}

	private void CreateGrid (){
		grid = new Node[gridSizeX, gridSizeY];

		for (int i = 0; i < gridSizeX; i++) {
			for (int o = 0; o < gridSizeY; o++) {
				Vector3 worldPoint = new Vector3 (i * nodeDiameter + nodeRadius, 0.5f, o * nodeDiameter + nodeRadius);
				bool walkable = !(Physics.CheckSphere(worldPoint, nodeRadius - 0.01f, unwalkableMask));
				grid [i, o] = new Node (walkable, worldPoint, i,o);
			}
		}
	}

	public Node NodeFormWolrdPoint(Vector3 _worldPoint){
		float percentX = _worldPoint.x/gridWorldSize.x;
		float percentY = _worldPoint.z/gridWorldSize.y;
		percentX = Mathf.Clamp01 (percentX);
		percentY = Mathf.Clamp01 (percentY);

		int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
		int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);

		return grid [x, y];
	}

	public List<Node> GetNeighbors(Node node){
		List<Node> neighbors = new List<Node> ();
		for(int i = -1; i <  2; i ++){
			for(int o = -1; o < 2; o ++){
				if(i == 0 && o == 0){
					continue;
				}
				int checkX = node.GetGridX() + i;
				int checkY = node.GetGridY() + o;
				if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY){
					neighbors.Add (grid[checkX, checkY]);
				}
			}
		}
		return neighbors;
	}

	public void SetPath(List<Node> _path, Node _startNode, Node _endNode){
		path = _path;
		StartNode = _startNode;
		EndNode = _endNode;
	}

	public int GetNodeDiameter(){
		return nodeDiameter;
	} 

	public LayerMask GetLayerMask(){
		return unwalkableMask;
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathfinderSRD : MonoBehaviour {

	private Astar grid;

	[SerializeField]private GameObject target;
	[SerializeField]private GameObject start;

	//private List<Node> path = new List<Node>();
	//private List<Node> smoothPath = new List<Node> ();

	// Use this for initialization
	void Start () {
		grid = GetComponent<Astar> ();
		FindPath (start.transform.position, target.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		//FindPath (start.transform.position, target.transform.position);
	}

	private void FindPath (Vector3 startPos, Vector3 targetPos){
		Node startNode = grid.NodeFormWolrdPoint (startPos);
		Node targetNode = grid.NodeFormWolrdPoint (targetPos);

		//Debug.Log (new Vector2(startNode.GetGridX(), startNode.GetGridY()));

		List<Node> openSet = new List<Node> ();
		List<Node> closedSet = new List<Node> ();
		openSet.Add (startNode);

		while(openSet.Count > 0){
			Node currentNode = openSet [0];
			for(int i = 1; i < openSet.Count; i ++){
				if (openSet[i].GetfCost() < currentNode.GetfCost()|| (openSet[i].GetfCost() == currentNode.GetfCost() && openSet[i].GethCost() < currentNode.GethCost())){
					currentNode = openSet [i];
				}
			}
			openSet.Remove (currentNode);
			closedSet.Add (currentNode);

			if(currentNode == targetNode){
				RetracePath (startNode, targetNode);
				return;
			}

			foreach(Node neighbor in grid.GetNeighbors(currentNode)){
				if((neighbor.GetWalkable() == false)|| closedSet.Contains(neighbor)){
					continue;
				}

				int newMovementCostToNeighbor = currentNode.GetgCost() + GetDistance (currentNode, neighbor);
				if(newMovementCostToNeighbor < neighbor.GetgCost() || !openSet.Contains(neighbor)){
					neighbor.SetgCost (newMovementCostToNeighbor);
					neighbor.SethCost (GetDistance(neighbor, targetNode));
					neighbor.SetParent (currentNode);

					if (!openSet.Contains (neighbor)) {
						openSet.Add (neighbor);
					}
				}
			}
		}
	}

	int GetDistance(Node nodeA, Node nodeB){
		int distanceX = Mathf.Abs (nodeA.GetGridX() - nodeB.GetGridX());
		int distanceY = Mathf.Abs (nodeA.GetGridY () - nodeB.GetGridY ());
		///*
		if (distanceX > distanceY) {
			return (14 * distanceY) + (10 * (distanceX - distanceY));
			//return 10 * distanceY + (10 * (distanceX - distanceY));
		} else {
			return (14 * distanceX) + (10 * (distanceY - distanceX));
			//return 10 * distanceX + (10 * (distanceY - distanceX));
		}
		//*/
		//return 10 * (distanceX + distanceY);
		//return 10 * distanceX 
	}

	void RetracePath(Node startNode, Node targetNode){
		List<Node> path = new List<Node> ();
		Node currentNode = targetNode;

		while(currentNode != startNode){
			path.Add (currentNode);
			currentNode = currentNode.GetParent();
		}
		path.Reverse ();

		grid.SetPath(path, startNode, targetNode);

		RefinePath (path);
	}

	private void RefinePath (List<Node> path){
		List<Node> smoothPath = new List<Node> ();
		int nodeDiameter = grid.GetNodeDiameter ();
		for (int i = 0; i < path.Count; i++) {
			Debug.Log (i);
			Vector3 currentPoint = path[i].GetWorldPos();
			for (int o = i + 1; o < path.Count; o ++){
				Vector3 endPoint = path[o].GetWorldPos();
				bool there = false;
				///*
				while(!there){
					currentPoint = Vector3.MoveTowards (currentPoint, endPoint, 0.1f);
					Node CurrentNode = grid.NodeFormWolrdPoint(currentPoint);
					if(CurrentNode == path[i]){
						continue;
					}else if(CurrentNode == path[o]){
						there = true;
					}else if(CurrentNode.GetWalkable() == false){
						smoothPath.Add (path[o-1]);
						i = o - 1;
						Debug.Log (o);
						break;
					}
				}
				//*/
				if(!there){
					break;
				}
			}
		}
		smoothPath.Add (path [path.Count - 1]);
		///*
		foreach(Node n in smoothPath){
			Debug.Log (n.GetWorldPos());
		}
		//*/
		//Debug.Log (smoothPath);
		//grid.SetPath(path, startNode, targetNode);

	}
	/*
	public List<Node> GetPath(){
		return path;
	}
	*/
}

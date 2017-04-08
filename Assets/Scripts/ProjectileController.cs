using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {

	private string ownerTag;
	[SerializeField]private float moveSpeed;
	private int power;
	private GameObject parent;
	[SerializeField]private int pierces;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (transform.forward * moveSpeed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider trigger){
		if(trigger.gameObject != parent){
			if(!trigger.isTrigger){
				pierces--;
				if(pierces < 0){
					Object.Destroy (gameObject);
				}
			}

		}
	}

	public void SetStuff(GameObject _parent, int _pierces){
		ownerTag = _parent.tag;
		parent = _parent;
		pierces = _pierces;
	}

}

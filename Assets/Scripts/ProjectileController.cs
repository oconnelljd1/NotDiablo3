using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {

	private string ownerTag;
	[SerializeField]private float moveSpeed;
	private int power;
	private GameObject parent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (transform.forward * moveSpeed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider trigger){
		if(trigger.gameObject != parent){
			Object.Destroy (gameObject);
		}
	}

	public void SetStuff(GameObject _parent){
		ownerTag = _parent.tag;
		parent = _parent;
	}

}

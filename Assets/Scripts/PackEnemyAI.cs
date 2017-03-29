using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class PackEnemyAI : MonoBehaviour {

	private PublicFunctions publicFunctions;

	private bool aggro = false;
	private GameObject target = null;
	[SerializeField]private float reach;
	[SerializeField]private float moveSpeed;
	[SerializeField]private WeaponController[] weapons;
	[SerializeField]private SphereCollider myRadius;
	private float attackDelay = 1.5f;
	private float lastAttack = 0;
	private GameObject weapon;

	private HealthController myHealth;

	private GameObject closestAlly;
	private List<GameObject> allies = new List<GameObject>();
	private bool desperate;

	private UnityAction PackEnemyDeath;
	private bool dead = false;

	// Use this for initialization
	void Start () {
		CheckForAllies ();
		weapon = transform.GetChild (0).gameObject;
		myHealth = GetComponent<HealthController> ();
		publicFunctions = new PublicFunctions();
	}
	
	// Update is called once per frame
	void Update () {
		WeaponController selectedAttack = null;
		if(desperate){
			if (closestAlly != null) {
				publicFunctions.MoveTowards (gameObject, closestAlly.transform.position, moveSpeed);
				Vector3 displacement = transform.position - closestAlly.transform.position; 
				if(displacement.sqrMagnitude < 25){
					desperate = false;
				}
			} else {
				if(target != null){
					selectedAttack = publicFunctions.AttackFuntcion (weapons, myHealth, Vector3.Distance(transform.position, target.transform.position));
					if (selectedAttack == null) {
						publicFunctions.MoveTowards (gameObject, target.transform.position, moveSpeed);
					} else {
						selectedAttack.Attack ();
					}
				}
			}
		}else if(aggro){
			selectedAttack = publicFunctions.AttackFuntcion (weapons, myHealth, Vector3.Distance(transform.position, target.transform.position));
			if (selectedAttack == null) {
				publicFunctions.MoveTowards (gameObject, target.transform.position, moveSpeed);
			} else {
				selectedAttack.Attack ();
			}
		}
	}

	void OnEnable(){
		EventManager.StartListening ("PackEnemyDeath", CheckForAllies);
	}

	void OnDisable(){
		OnDeath ();
	}

	void OnTriggerEnter(Collider trigger){
		if(trigger.CompareTag("Player")){
			Debug.Log (trigger);
				aggro = true;
				target = trigger.gameObject;
		}
	}

	void OnTriggerExit(Collider trigger){
		if (publicFunctions.ExitTrigger(trigger, myRadius)) {
			target = null;
			aggro = false;
		}
	}

	private void CheckForAllies(){
		if(!dead){
			//Debug.Log ("checking");
			Collider[] localAllies = Physics.OverlapSphere (transform.position, 15);
			foreach (Collider LA in localAllies) {
				if (LA.tag == "enemy") {
					return;
				}
			}
			desperate = true;
			allies = new List<GameObject> ();
			Collider[] items = Physics.OverlapSphere (transform.position, 15);
			foreach (Collider i in items) {
				if (i.tag == "enemy") {
					allies.Add (i.gameObject);
				}
			}
			closestAlly = null;
			if (allies.Count > 0) {
				Vector3 displacement = allies [0].transform.position - transform.position;
				closestAlly = allies [0];
				foreach (GameObject ally in allies) {
					Vector3 newDisplacement = ally.transform.position - transform.position;
					if (newDisplacement.sqrMagnitude < displacement.sqrMagnitude) {
						closestAlly = ally;
					}
				}
			}else {
				aggro = true;
				return;
			}
		}
	}

	void OnDeath(){
		//Debug.Log ("onDeath");
		dead = true;
		EventManager.TriggerEvent ("PackEnemyDeath");
	}

}

using UnityEngine;
using System.Collections;

public class BroodlingEnemyAI : MonoBehaviour {

	private BroodEnemyAI parent;

	private bool aggro;
	private GameObject target;
	[SerializeField]private float moveSpeed = 1;
	private GameObject weapon;

	private HealthController myHealth;
	[SerializeField]private WeaponController[] weapons;

	private PublicFunctions publicFunctions;
	[SerializeField]private SphereCollider myRadius;

	void Awake(){
		publicFunctions = new PublicFunctions();
	}

	// Use this for initialization
	void Start () {
		myHealth = GetComponent<HealthController> ();
		weapon = transform.GetChild (0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		WeaponController selectedAttack = null;
		if(target != null){
			selectedAttack = publicFunctions.AttackFuntcion (weapons, GetComponent<HealthController> (), Vector3.Distance(transform.position, target.transform.position));
			if (selectedAttack == null) {
				publicFunctions.MoveTowards (gameObject, target.transform.position, moveSpeed);
			} else {
				selectedAttack.Attack ();
			}
		}
	}

	void OnTriggerEnter(Collider trigger){
		if(trigger.CompareTag("Player")){
			aggro = true;
			target = trigger.gameObject;
		}
	}

	void OnTriggerExit(Collider trigger){
		if (trigger && target) {
			if (publicFunctions.ExitTrigger (trigger, myRadius, gameObject)) {
				target = null;
				aggro = false;
			}
		}
	}

	public void SetParent(BroodEnemyAI _parent){
		parent = _parent;
	}

	private void Death(){
		parent.ChildDeath ();
	}
}

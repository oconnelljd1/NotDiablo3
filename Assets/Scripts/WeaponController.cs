using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

	private Collider hitbox;

	[SerializeField]private Collider myCollider;
	[SerializeField]private Sprite mySprite;

	[SerializeField]private string ownerTag;
	[SerializeField]private bool support = false;
	[SerializeField]private bool ranged = false;
	[SerializeField]private GameObject projectile;

	[SerializeField] private float attackDelay, supportDuration, attackCoolDown, manaCost, reach;

	[SerializeField]private int damageValue, damageMultiplier;
	[SerializeField]private int lightningDamageValue, lightningDamageMultiplier;
	[SerializeField]private int fireDamageValue, fireDamageMultiplier;
	[SerializeField]private int iceDamageValue, iceDamageMultiplier;

	[SerializeField]private int armorValue, armorMultiplier;
	[SerializeField]private int lightningArmorValue, lightningArmorMultiplier;
	[SerializeField]private int fireArmorValue, fireArmorMultiplier;
	[SerializeField]private int iceArmorValue, iceArmorMultiplier;

	// Use this for initialization
	void Start () {
		myCollider = GetComponent<Collider> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void Attack(){
		IEnumerator attackCoroutine;
		if (support) {
			attackCoroutine = SupportDuration (supportDuration);
		} else {
			attackCoroutine = AttackDuration (attackDelay);
		}
		StartCoroutine (attackCoroutine);
	}

	private IEnumerator AttackDuration(float _duration){
		GetComponent<HealthController> ().BoostStats (this, +1);
		if (ranged) {
			ProjectileController newProjectile = Instantiate (projectile, transform.position + transform.forward, transform.rotation) as ProjectileController;
			newProjectile.SetStuff (gameObject);
		} else {
			hitbox = transform.parent.gameObject.GetComponent<Collider> ();
			hitbox = myCollider;
			hitbox.enabled = true;
		}
		yield return new WaitForSeconds(_duration);
		if (!ranged) {
			GetComponent<Collider>().enabled = false;
		}
		GetComponent<HealthController> ().BoostStats (this, -1);
	}

	private IEnumerator SupportDuration(float _duration){
		GetComponent<HealthController> ().BoostStats (this, +1);
		yield return new WaitForSeconds(_duration);
		GetComponent<HealthController> ().BoostStats (this, -1);
	}

	public float GetAttackDelay(){
		return attackDelay;
	}

	public float GetAttackCoolDown(){
		return attackCoolDown;
	}

	public float GetManaCost(){
		return manaCost;
	}

	public float GetReach(){
		return reach;
	}

	public Sprite GetSprite(){
		return mySprite;
	}

	void OnTriggerEnter(Collider trigger){
		if(trigger.gameObject.GetComponent<HealthController>() != null){
			if(!trigger.CompareTag(ownerTag)){
				HealthController enemyHealth = trigger.gameObject.GetComponent<HealthController> ();
				HealthController myHealth = GetComponentInParent<HealthController> ();
				int damage = enemyHealth.GetCurrentArmor() - myHealth.GetCurrentDamage();
				int lightningDamage = enemyHealth.GetCurrentLightningArmor () - myHealth.GetCurrentLightningDamage ();
				int fireDamage = enemyHealth.GetCurrentFireArmor () - myHealth.GetCurrentFireDamage ();
				int iceDamage = enemyHealth.GetCurrentIceArmor () - myHealth.GetCurrentIceDamage ();
				if(damage < 0){
					damage = 0;
				}
				if(lightningDamage < 0){
					lightningDamage = 0;
				}
				if(fireDamage < 0){
					fireDamage = 0;
				}
				if(iceDamage < 0){
					iceDamage = 0;
				}
				int totalDamage = damage + lightningDamage + fireDamage + iceDamage;
				enemyHealth.Damage (totalDamage);
			}
		}
	}

	public int GetDamageValue(){
		return damageValue;
	}

	public int GetDamageMultiplier (){
		return damageMultiplier;
	}

	public int GetLightningDamageValue(){
		return lightningDamageValue;
	}

	public int GetLightningDamageMultiplier (){
		return lightningDamageMultiplier;
	}

	public int GetFireDamageValue(){
		return fireDamageValue;
	}

	public int GetFireDamageMultiplier (){
		return fireDamageMultiplier;
	}

	public int GetIceDamageValue(){
		return iceDamageValue;
	}

	public int GetIceDamageMultiplier (){
		return iceDamageMultiplier;
	}

	public int GetArmorValue(){
		return armorValue;
	}

	public int GetArmorMultiplier (){
		return armorMultiplier;
	}

	public int GetLightningArmorValue(){
		return lightningArmorValue;
	}

	public int GetLightningArmorMultiplier (){
		return lightningArmorMultiplier;
	}

	public int GetFireArmorValue(){
		return fireArmorValue;
	}

	public int GetFireArmorMultiplier (){
		return fireArmorMultiplier;
	}

	public int GetIceArmorValue(){
		return iceArmorValue;
	}

	public int GetIceArmorMultiplier (){
		return iceArmorMultiplier;
	}

}

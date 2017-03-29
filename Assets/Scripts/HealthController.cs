using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {

	[SerializeField]private int healthValue = 100, healthModifier = 100;
	private int currentHealth, currentMana;
	[SerializeField]private int manaValue = 100, manaModifier = 100;

	[SerializeField] private int damageValue, damageMultiplier;
	[SerializeField] private int lightningDamageValue, lightningDamageMultiplier;
	[SerializeField] private int fireDamageValue, fireDamageMultiplier;
	[SerializeField] private int iceDamageValue, iceDamageMultiplier;

	[SerializeField] private int armorValue, armorMultiplier;
	[SerializeField] private int lightningArmorValue, lightningArmorMultiplier;
	[SerializeField] private int fireArmorValue, fireArmorMultiplier;
	[SerializeField] private int iceArmorValue, iceArmorMultiplier;



	// Use this for initialization
	void Start () {
		currentHealth = healthValue * healthModifier / 100;
		currentMana = manaValue * manaModifier / 100;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Damage (int _damage) {
		currentHealth -= _damage;
		if(currentHealth < 1){
			Object.Destroy (gameObject);
		}
	}

	public void SetMaxHealth (int _maxHealth) {
		healthValue = _maxHealth;
	}

	public void ChangeStats(EquipmentController _equipment, int _posNeg){
		damageValue += _equipment.GetDamageValue() * _posNeg;
		lightningDamageValue += _equipment.GetLightningDamageValue () * _posNeg;
		fireDamageValue += _equipment.GetFireDamageValue () * _posNeg;
		iceDamageValue += _equipment.GetIceDamageValue () * _posNeg;

		armorValue += _equipment.GetArmorValue () * _posNeg;
		lightningArmorValue += _equipment.GetLightningArmorValue () * _posNeg;
		fireArmorValue += _equipment.GetFireArmorValue () * _posNeg;
		iceArmorValue += _equipment.GetIceArmorValue () * _posNeg;

		damageMultiplier += _equipment.GetDamageMultiplier () * _posNeg;
		lightningDamageMultiplier += _equipment.GetLightningDamageMultiplier () * _posNeg;
		fireDamageMultiplier += _equipment.GetLightningDamageMultiplier () * _posNeg;
		iceDamageMultiplier += _equipment.GetIceDamageMultiplier () * _posNeg;

		armorMultiplier += _equipment.GetArmorMultiplier () * _posNeg;
		lightningArmorMultiplier += _equipment.GetLightningArmorMultiplier () * _posNeg;
		fireArmorMultiplier += _equipment.GetFireArmorMultiplier () * _posNeg;
		iceArmorMultiplier += _equipment.GetIceArmorMultiplier () * _posNeg;
	}

	public int GetDamageValue(){
		return damageValue;
	}

	public int GetLightningDamageValue(){
		return lightningDamageValue;
	}

	public int GetFireDamageValue(){
		return fireDamageValue;
	}

	public int GetIceDamageValue(){
		return iceDamageValue;
	}

	public int GetArmorValue(){
		return armorValue;
	}

	public int GetLightningArmorValue(){
		return lightningArmorValue;
	}

	public int GetFireArmorValue(){
		return fireArmorValue;
	}

	public int GetIceArmorValue(){
		return iceArmorValue;
	}

	public int GetDamageMultiplier(){
		return damageMultiplier;
	}

	public int GetLightningDamageMultiplier(){
		return lightningDamageMultiplier;
	}

	public int GetFireDamageMultiplier(){
		return fireDamageMultiplier;
	}

	public int GetIceDamageMultiplier(){
		return iceDamageMultiplier;
	}

	public int GetArmorMultiplier(){
		return armorMultiplier;
	}

	public int GetLightningArmorMultiplier(){
		return lightningArmorMultiplier;
	}

	public int GetFireArmorMultiplier(){
		return fireArmorMultiplier;
	}

	public int GetIceArmorMultiplier(){
		return iceArmorMultiplier;
	}

	public int GetCurrentDamage(){
		return damageValue * damageMultiplier / 100;
	}

	public int GetCurrentLightningDamage(){
		return lightningDamageValue * lightningDamageMultiplier / 100;
	}

	public int GetCurrentFireDamage(){
		return fireDamageValue * fireDamageMultiplier / 100;
	}
	public int GetCurrentIceDamage(){
		return iceDamageValue * iceDamageMultiplier / 100;
	}

	public int GetCurrentArmor(){
		return armorValue * armorMultiplier / 100;
	}

	public int GetCurrentLightningArmor(){
		return lightningArmorValue * lightningArmorMultiplier / 100;
	}

	public int GetCurrentFireArmor(){
		return fireArmorValue * fireArmorMultiplier / 100;
	}

	public int GetCurrentIceArmor(){
		return iceArmorValue * iceArmorMultiplier / 100;
	}

	public void BoostStats(WeaponController _weapon, int _posNeg){
		damageValue += _weapon.GetDamageValue() * _posNeg;
		lightningDamageValue += _weapon.GetLightningDamageValue () * _posNeg;
		fireDamageValue += _weapon.GetFireDamageValue () * _posNeg;
		iceDamageValue += _weapon.GetIceDamageValue () * _posNeg;

		armorValue += _weapon.GetArmorValue () * _posNeg;
		lightningArmorValue += _weapon.GetLightningArmorValue () * _posNeg;
		fireArmorValue += _weapon.GetFireArmorValue () * _posNeg;
		iceArmorValue += _weapon.GetIceArmorValue () * _posNeg;

		damageMultiplier += _weapon.GetDamageMultiplier () * _posNeg;
		lightningDamageMultiplier += _weapon.GetLightningDamageMultiplier () * _posNeg;
		fireDamageMultiplier += _weapon.GetLightningDamageMultiplier () * _posNeg;
		iceDamageMultiplier += _weapon.GetIceDamageMultiplier () * _posNeg;

		armorMultiplier += _weapon.GetArmorMultiplier () * _posNeg;
		lightningArmorMultiplier += _weapon.GetLightningArmorMultiplier () * _posNeg;
		fireArmorMultiplier += _weapon.GetFireArmorMultiplier () * _posNeg;
		iceArmorMultiplier += _weapon.GetIceArmorMultiplier () * _posNeg;
	}

	public int GetCurrentMana(){
		return currentMana;
	}
}

﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WeaponManager : MonoBehaviour {

	public static WeaponManager instance;

	private WeaponController[] equippedWeapons = new WeaponController[7];
	private List<WeaponController> weapons = new List<WeaponController>(){null, null, null, null, null, null, null, null, null, null};
	[SerializeField]private Image[] weaponImages;

	private WeaponController lastWeapon, nextWeapon, currentWeapon;
	private float lastAttack;

	private HealthController myHealthController;

	void Awake(){
		if(instance != null){
			Object.Destroy (gameObject);
		}else{
			instance = this;
			Object.DontDestroyOnLoad (gameObject);
		}
		myHealthController = GetComponent<HealthController> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*KEEP THIS, NEEDS TO BE ADDED TO PLAYER CONTROLLER
		for (int i = 0; i < equippedWeapons.Length; i++){
			if(Input.GetAxisRaw("Weapon" + (i +1)) == 1){
				if (equippedWeapons [i] == lastWeapon) {
					if (Time.time > lastAttack + lastWeapon.GetAttackCoolDown ()) {
						lastWeapon.Attack ();
						lastAttack = Time.time;
					}
				} else {
					if(Time.time > lastAttack + lastWeapon.GetAttackDelay()){
						equippedWeapons [i].Attack ();
						lastAttack = Time.time;
					}
				}
			}
		}
		*/

		for(int i =1; i< equippedWeapons.Length; i++){
			if(Input.GetButtonDown("Weapon" + (i+1))){
				if(equippedWeapons[i]){
					nextWeapon = equippedWeapons [i];
					TryAttack ();
				}
			}
		}
	}

	public void AddWeapon(WeaponController _weapon){
		weapons.Add (_weapon);
		for(int i = 0; i < equippedWeapons.Length; i++){
			if(equippedWeapons[i] == null){
				equippedWeapons [i] = _weapon;
				break;
			}	
		}
	}

	public void EquipWeapon(int _index){
		for(int i = 1; i< equippedWeapons.Length; i++){
			if(equippedWeapons[i] == currentWeapon){
				equippedWeapons [i] = null;
			}
		}
		equippedWeapons [_index] = currentWeapon;
		currentWeapon = null;
	}

	public void HoldWeapon(int _index){
		currentWeapon = weapons [_index];
	}

	public void EquipPrimary(WeaponController _weaponC){
		equippedWeapons [0] = _weaponC;
	}

	public void UnequipWeapon(int _index){
		equippedWeapons [_index] = null;
	}

	public float GetPrimarySqrRange(){
		if (weapons [0]) {
			return Mathf.Pow (weapons [0].GetReach (), 2);
		} else {
			return 0;
		}
	}

	public void TryAttack(){
		if(Time.time > lastAttack +lastWeapon.GetAttackDelay()){
			if (nextWeapon.GetManaCost () <= myHealthController.GetCurrentMana ()) {
				nextWeapon.Attack ();
				lastWeapon = nextWeapon;
				lastAttack = Time.time;
				nextWeapon = equippedWeapons [0];
			}
		}
	}

	public WeaponController[] GetEquippedWeapons(){
		return equippedWeapons;
	}

	public int GetNextWeapon(){
		for(int i = 0;i < 7; i++){
			if(equippedWeapons[i]){
				if(equippedWeapons[i] == nextWeapon){
					return i;
				}
			}
		}
		return 0;
	}

	public WeaponController GetPrimaryWeapon(){
		return equippedWeapons [0];
	}

}

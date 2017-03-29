﻿using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour {

	[SerializeField]private Sprite sprite;
	[SerializeField]private bool stackable = false;

	private bool isWeapon, isEquipmenet, isStackable;

	// Use this for initialization
	void Start () {
		if(GetComponent<EquipmentController>()){
			isEquipmenet = true;
			if(GetComponent<WeaponController>()){
				isWeapon = true;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Set3D(bool _bool){
		gameObject.SetActive (_bool);
	}

	public Sprite GetSprite(){
		return sprite;
	}

}

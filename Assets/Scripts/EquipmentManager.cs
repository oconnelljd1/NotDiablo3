using UnityEngine;
using System.Collections;

public class EquipmentManager : MonoBehaviour {

	public static EquipmentManager instance;

	private EquipmentController tempEquip;
	[SerializeField]EquipmentController[] equipment = new EquipmentController[10];
	private string[] equipmentTypes = new string[10] {"chest","arms","legs","head","ring","ring","necklace", "belt","weapon","weapon"};

	private HealthController myHealth;

	void Awake(){
		if(instance != null){
			Object.Destroy (gameObject);
		}else{
			instance = this;
			Object.DontDestroyOnLoad (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		myHealth = GetComponent<HealthController> ();
	}

	public void Equip(int _index, EquipmentController _equipC){
		if (_equipC.GetEquipmentType () == equipment [_index].GetEquipmentType ()) {
			if (_equipC.GetEquipmentType () != "weapon") {
				myHealth.ChangeStats (_equipC, 1);
				myHealth.ChangeStats (equipment [_index], -1);
				equipment [_index] = _equipC;
			} else {
				if (_equipC.GetTwohanded () && equipment [8] && equipment [9]) {
					return;
				}
				if (_index == 9 && equipment [8].GetTwohanded ()) {
					_index = 8;
				}
				myHealth.ChangeStats (_equipC, 1);
				myHealth.ChangeStats (equipment [_index], -1);
				tempEquip = _equipC;
				equipment [_index] = _equipC;
				ItemManager.instance.AddItemToInventory (_equipC.gameObject.GetComponent<ItemController> ());	

				if (!equipment [8]) {
					equipment [8] = equipment [9];
					equipment [9] = null;
				}
				WeaponManager.instance.EquipPrimary (_equipC.GetComponent<WeaponController>());
			}
		}
	}

	public void UnEquip(int _index){
		myHealth.ChangeStats (equipment[_index], -1);
		equipment [_index] = null;
		if (!equipment [8]) {
			equipment [8] = equipment [9];
			equipment [9] = null;
		}
	}

	public EquipmentController GetEquipment(int _index){
		return equipment [_index];
	}

}

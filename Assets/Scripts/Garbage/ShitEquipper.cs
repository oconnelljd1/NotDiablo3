/*
public void Equip(int _index, EquipmentController _equipC){
		if (equipment [_index]) {
			if (_equipC.GetEquipmentType () == equipmentTypes [_index]) {
				if (_equipC.GetEquipmentType () != "weapon") {
					myHealth.ChangeStats (_equipC, 1);
					myHealth.ChangeStats (equipment [_index], -1);
					equipment [_index] = _equipC;
					equipmentImages [_index].sprite = equipment [_index].gameObject.GetComponent<ItemController> ().GetSprite ();
				} else {
					if (_equipC.GetTwohanded () && equipment [8] && equipment [9]) {
						return;
					}
					if (_index == 9 && equipment [8].GetTwohanded ()) {
						_index = 8;
					}
					myHealth.ChangeStats (_equipC, 1);

					tempEquip = _equipC;
					equipment [_index] = _equipC;
					ItemManager.instance.AddItemToInventory (_equipC.gameObject.GetComponent<ItemController> ());	

					if (!equipment [8]) {
						equipment [8] = equipment [9];
						equipment [9] = null;
					}
					WeaponManager.instance.EquipPrimary (_equipC.GetComponent<WeaponController> ());
					equipmentImages [_index].sprite = equipment [_index].gameObject.GetComponent<ItemController> ().GetSprite ();
				}
			} else {
				Debug.Log ("Types Don't Match");
			}
		} else {
			myHealth.ChangeStats (equipment [_index], -1);
			equipmentImages [_index].sprite = null;
			ItemManager.instance.AddItemToInventory (equipment[_index].gameObject.GetComponent<ItemController>());
			equipment [_index] = null;
		}
	}
    */
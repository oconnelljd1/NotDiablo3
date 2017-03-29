using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour {

	public static ItemManager instance;

	private ItemController currentItem;
	private int currentInt;

	private List<ItemController> inventory = new List<ItemController>();

	//[SerializeField] private GameObject image;
	//[SerializeField] private GameObject inv;

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
	}
	
	// Update is called once per frame
	void Update () {
		/* KEEP THIS, NEEDS TO BE MOVED TO PLAYER CONTROLLER
		if(Input.GetMouseButtonDown(0)){
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity)){
				if (hit.collider.CompareTag ("Item")) {
					if(!inv.activeInHierarchy){
						ItemController newItem = hit.collider.GetComponent<ItemController> ();
						inventory.Add (newItem);
						newItem.Set3D (false);
					}
				}
			}
		}
		*/
	}

	public void InteractWithInventory(int _index){
		if (currentItem) {
			ItemController tempItem = inventory [_index];
			inventory [_index] = currentItem;
			inventory [currentInt] = tempItem;
			currentItem = null;
		} else {
			currentItem = inventory [_index];
			currentInt = _index;
		}
	}

	public void InteractWithEquipment(int _index){
		if (currentItem) {
			EquipmentController currentEquip = currentItem.gameObject.GetComponent<EquipmentController> ();
			if (currentEquip) {
				EquipmentManager.instance.Equip (_index, currentEquip);
			}
			currentItem = null;
		} else {
			WeaponManager.instance.UnequipPrimary ();
			inventory.Add (EquipmentManager.instance.GetEquipment (_index).gameObject.GetComponent<ItemController>());
			EquipmentManager.instance.UnEquip (_index);
		}
	}

	public int GetInventoryCount(){
		return inventory.Count;
	}

	public void AddItemToInventory(ItemController _itemC){
		inventory.Add (_itemC);
		_itemC.gameObject.transform.SetParent (transform.GetChild(0).transform);
		_itemC.gameObject.transform.localPosition = Vector3.zero;
		_itemC.gameObject.transform.localRotation = Quaternion.Euler (Vector3.zero);
		_itemC.gameObject.SetActive (false);
	}

}

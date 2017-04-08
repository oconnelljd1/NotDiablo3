using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour {

	public static ItemManager instance;

	private ItemController currentItem;
	private int currentInt;

	private List<ItemController> inventory = new List<ItemController>();
	[SerializeField]private ScrollabelInventory myScrollInv;

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
			if (_index<inventory.Count) {
				currentItem = inventory [_index];
				currentInt = _index;
			}
		}
		Debug.Log (currentItem);
		myScrollInv.UpdateInventory ();
	}

	public void InteractWithEquipment(int _index){
		if (currentItem) {
			if (currentItem.gameObject.GetComponent<EquipmentController> ()) {
				EquipmentController currentEquip = currentItem.gameObject.GetComponent<EquipmentController> ();
				EquipmentManager.instance.Equip (_index, currentEquip);
			}
			currentItem = null;
		} else {
			if(_index == 8 || _index == 9){
				WeaponManager.instance.UnequipWeapon (0);
			}
			currentItem = null;
		}
		myScrollInv.UpdateInventory ();
	}

	public int GetInventoryCount(){
		return inventory.Count;
	}

	public void AddItemToInventory(ItemController _itemC){
		inventory.Add (_itemC);
		_itemC.gameObject.transform.SetParent (transform.GetChild(0).transform);
		_itemC.gameObject.transform.localPosition = Vector3.zero;
		_itemC.gameObject.transform.localRotation = Quaternion.Euler (Vector3.zero);
		_itemC.gameObject.transform.GetChild(0).gameObject.SetActive (false);
	}

	public void RemoveItem(ItemController _itemC){
		inventory.Remove (_itemC);
	}

	public List<ItemController> GetInventory	(){
		return inventory;
	}

}

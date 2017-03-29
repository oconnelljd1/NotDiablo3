using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemSlotController : MonoBehaviour {

	private Toggle myToggle;

	[SerializeField]private int myIndex;
	[SerializeField]private bool isItem;

	void Awake(){
		
	}

	// Use this for initialization
	void Start () {
		myToggle = GetComponent<Toggle> ();
		myToggle.onValueChanged.AddListener(delegate{
			if(myToggle.isOn){
				//Debug.Log("changing Value" + myIndex + myToggle.isOn);
				if(isItem){
					ItemManager.instance.InteractWithInventory (myIndex);
				}else{
					WeaponManager.instance.HoldWeapon(myIndex);
				}
			}
		});
	}

	public void SetStuff(int _index, bool _TF){
		myIndex = _index;
		isItem = _TF;
	}
}

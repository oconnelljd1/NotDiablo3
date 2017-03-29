using UnityEngine;
using System.Collections;

public class WindowManager : MonoBehaviour {

	[SerializeField]private GameObject inventory, character, map, quests;
	private ScrollabelInventory myInv;
	private CharacterScreenController myChar;

	// Use this for initialization
	void Start () {
		myInv = inventory.GetComponent<ScrollabelInventory> ();
		myChar = character.GetComponent<CharacterScreenController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.I)){
			inventory.SetActive (!inventory.activeInHierarchy);
			if(inventory.activeInHierarchy){
				myInv.CreateExtraInventorySlotsInWindow ();
			}
		}else if(Input.GetKeyDown(KeyCode.C)){
			character.SetActive (!character.activeInHierarchy);
			if(character.activeInHierarchy){
				myChar.SetStatTexts ();
			}
		}else if(Input.GetKeyDown(KeyCode.M)){
			map.SetActive (!character.activeInHierarchy);
		}else if(Input.GetKeyDown(KeyCode.B)){
			quests.SetActive (!character.activeInHierarchy);
		}
	}

	public void CloseInventory(){
		Debug.Log ("notthere");
		myInv.DestroyExtraInventorySlotsInWindow ();
		Debug.Log ("got here");
		inventory.SetActive (false);
	}

	public void CloseCharacter(){
		character.SetActive (false);
	}

	public void CloseMap(){
		map.SetActive (false);
	}

	public void CloseQuests(){
		quests.SetActive (false);
	}

}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMnuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(ItemManager.instance){
			Object.Destroy (ItemManager.instance.gameObject);
		}
		if(WindowManager.instance){
			Object.Destroy (WindowManager.instance.GetEventSystem());
			Object.Destroy (WindowManager.instance.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadGame(){
		SceneManager.LoadScene ("Town1");
	}

	public void QuitGame(){
		Application.Quit();
	}
}

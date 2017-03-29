using UnityEngine;
using System.Collections;

public class FizzBuzz : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string myString = "";
		for(int i = 1; i < 101; i ++){
			myString = "";
			if(i%3 == 0){
				myString += "Fizz";
			}
			if(i % 5 == 0){
				myString += "Buzz";
			}
			if(myString == ""){
				myString = "" + i;
			}
			Debug.Log (myString);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

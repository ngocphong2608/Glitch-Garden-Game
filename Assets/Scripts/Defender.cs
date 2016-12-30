using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

	private StarDisplay starDisplay;

	void Start() {
		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();
	}


	void AddStars(int amount) {
		//Debug.Log (amount + "stars added");
		starDisplay.AddStars (amount);
	}
}

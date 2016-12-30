using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarDisplay : MonoBehaviour {

	private int stars = 0;
	private Text starLabel;

	// Use this for initialization
	void Start () {
		starLabel = GetComponent<Text> ();
		starLabel.text = stars.ToString ();
	}

	public void AddStars(int amount) {
		//Debug.Log (amount + " stars added");
		stars += amount;
		UpdateStarLabel ();
	}

	public void UseStars(int amount) {
		stars -= amount;
		UpdateStarLabel ();
	}

	void UpdateStarLabel() {
		starLabel.text = stars.ToString ();
	}
}

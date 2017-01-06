using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarDisplay : MonoBehaviour {

	public int stars = 100;
	private Text starLabel;

	public enum Status {SUCCESS, FAILURE};

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

	public Status UseStars(int amount) {
		if (amount <= stars) {
			stars -= amount;
			UpdateStarLabel ();
			return Status.SUCCESS;
		} 
		return Status.FAILURE;
	}

	void UpdateStarLabel() {
		starLabel.text = stars.ToString ();
	}
}

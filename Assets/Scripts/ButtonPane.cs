using UnityEngine;
using System.Collections;

public class ButtonPane : MonoBehaviour {

	public GameObject defenderPref;
	public static GameObject selectedDefender;

	ButtonPane[] buttons;

	// Use this for initialization
	void Start () {
		buttons = FindObjectsOfType<ButtonPane> ();
		GetComponent<SpriteRenderer> ().color = Color.gray;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (selectedDefender);
	}

	void OnMouseDown() {
		//Debug.Log (name + "pressed");
		foreach (ButtonPane btn in buttons) {
			btn.GetComponent<SpriteRenderer>().color = Color.gray;
		}
		GetComponent<SpriteRenderer> ().color = Color.white;
		selectedDefender = gameObject;
	}
}

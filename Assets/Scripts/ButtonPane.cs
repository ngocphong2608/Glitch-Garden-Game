using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonPane : MonoBehaviour {

	public GameObject defenderPref;
	public static GameObject selectedDefender;

	private ButtonPane[] buttons;
	private Text cost;

	// Use this for initialization
	void Start () {
		buttons = FindObjectsOfType<ButtonPane> ();
		GetComponent<SpriteRenderer> ().color = Color.gray;

		cost = GetComponentInChildren<Text> ();
		if (cost == null) {
			Debug.Log ("Can't find cost button");
		} else {
			cost.text = defenderPref.GetComponent<Defender>().starCost.ToString();
		}

		selectedDefender = null;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (selectedDefender);
	}

	void OnMouseDown() {
		//Debug.Log (name + "pressed");
		foreach (ButtonPane btn in buttons) {
			btn.GetComponent<SpriteRenderer>().color = Color.gray;
		}
		GetComponent<SpriteRenderer> ().color = Color.white;
		selectedDefender = defenderPref;
	}
}

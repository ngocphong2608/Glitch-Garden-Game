using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {


	public Camera mainCamera;

	private GameObject parent;

	void Start() {
		parent = GameObject.Find ("Defenders");
		if (parent == null) {
			parent = new GameObject("Defenders");
		}
	}

	void OnMouseDown() {
		if (ButtonPane.selectedDefender != null) {
			Vector2 rawPos = CalculateWorldPointOfMouseClick ();
			Vector2 roundPos = SnapToGrid (rawPos);
			GameObject obj = Instantiate (ButtonPane.selectedDefender, roundPos, Quaternion.identity) as GameObject;
			obj.transform.parent = parent.transform;
		}
	}
	 
	Vector2 CalculateWorldPointOfMouseClick() {
		return mainCamera.ScreenToWorldPoint (Input.mousePosition);
	}

	Vector2 SnapToGrid(Vector2 rawWorldPos){
		return new Vector2(Mathf.RoundToInt(rawWorldPos.x), Mathf.RoundToInt(rawWorldPos.y));
	}
}

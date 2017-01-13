using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour
{
	private static float Top = 5.5f, Bottom = 0.5f, Left = 0.5f, Right = 9.5f;
	public Camera mainCamera;

	private GameObject parent;
	private StarDisplay starDisplay;

	void Start ()
	{
		parent = GameObject.Find ("Defenders");
		if (parent == null) {
			parent = new GameObject ("Defenders");
		}
		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();
	}

	void Update() {
		if (Input.GetMouseButtonDown (0) ) {
			Vector2 rawPos = CalculateWorldPointOfMouseClick ();
			if (IsInCoreGame(rawPos)) {
				Vector2 roundPos = SnapToGrid (rawPos);
				
				if (ButtonPane.selectedDefender != null) {
					Defender def = ButtonPane.selectedDefender.GetComponent<Defender> ();
					if (starDisplay.UseStars (def.starCost) == StarDisplay.Status.SUCCESS) {
						SpawnDefender (roundPos);
					} else {
						Debug.Log ("Star is not enough");
					}
				}
			}
		}
	}

	bool IsInCoreGame (Vector2 p)
	{
		Debug.Log (p);
		if (p.x >= Left && p.x <= Right && p.y >= Bottom && p.y <= Top)
			return true;
		return false;
	}



	void SpawnDefender (Vector2 roundPos)
	{
		GameObject obj = Instantiate (ButtonPane.selectedDefender, roundPos, Quaternion.identity) as GameObject;
		obj.transform.parent = parent.transform;
	}
	 
	Vector2 CalculateWorldPointOfMouseClick ()
	{
		return mainCamera.ScreenToWorldPoint (Input.mousePosition);
	}

	Vector2 SnapToGrid (Vector2 rawWorldPos)
	{
		return new Vector2 (Mathf.RoundToInt (rawWorldPos.x), Mathf.RoundToInt (rawWorldPos.y));
	}
}

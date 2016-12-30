using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour
{


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

	void OnMouseDown ()
	{
		if (ButtonPane.selectedDefender != null) {
			Defender def = ButtonPane.selectedDefender.GetComponent<Defender> ();
			if (starDisplay.UseStars (def.starCost) == StarDisplay.Status.SUCCESS) {
				Vector2 rawPos = CalculateWorldPointOfMouseClick ();
				Vector2 roundPos = SnapToGrid (rawPos);
				SpawnDefender (roundPos);
			} else {
				Debug.Log ("Star is not enough");
			}
		}
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

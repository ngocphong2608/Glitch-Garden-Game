using UnityEngine;
using System.Collections;

public class LoseShredder : MonoBehaviour {

	public LevelManager manager;
	
	void OnTriggerEnter2D(Collider2D col) {
		manager.LoadLevel("03b_Lose");
	}
}

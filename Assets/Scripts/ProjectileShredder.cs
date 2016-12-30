using UnityEngine;
using System.Collections;

public class ProjectileShredder : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		Destroy (col.gameObject);
	}
}

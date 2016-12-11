using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health = 50f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// return true if target is dead
	public bool DealingDamage(float damage) {
		health -= damage;
		if (health <= 0)
			return true;
		return false;
	}
}

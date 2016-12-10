using UnityEngine;
using System.Collections;

public class Attackers : MonoBehaviour {

	[Range (-1f, 1.5f)]
	public float walkSpeed;

	// Use this for initialization
	void Start () {
		Rigidbody2D myRig = gameObject.AddComponent<Rigidbody2D> ();
		myRig.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D col) {
		Debug.Log (name + " triggered " + col.gameObject.name);
	}

	public void SetSpeed(float speed) {
		walkSpeed = speed;
	}

	public void StrikeCurrentTarget(float damage) {
		Debug.Log (name + " caused " + damage + " damage");
	}
}

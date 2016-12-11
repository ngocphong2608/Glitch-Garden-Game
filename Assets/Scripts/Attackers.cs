using UnityEngine;
using System.Collections;

public class Attackers : MonoBehaviour {
	
	float walkSpeed;
	GameObject currentTarget;
	Animator anim;

	// Use this for initialization
	void Start () {
		Rigidbody2D myRig = gameObject.AddComponent<Rigidbody2D> ();
		myRig.isKinematic = true;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D col) {
		//Debug.Log (name + " triggered " + col.gameObject.name);
	}

	public void SetSpeed(float speed) {
		walkSpeed = speed;
	}

	public void StrikeCurrentTarget(float damage) {
		//Debug.Log (name + " caused " + damage + " damage");
		if (currentTarget != null) {
			Health h = currentTarget.GetComponent<Health> ();
			bool isDead = h.DealingDamage(damage);
			if (isDead) {
				Destroy (currentTarget);
				currentTarget = null;
				anim.SetBool("IsAttacking", false);
			}
		}
	}

	public void Attack(GameObject obj) {
		currentTarget = obj;
	}
}

using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {
	
	float walkSpeed;
	GameObject currentTarget;
	Animator anim;
	Health health;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		health = GetComponent<Health> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D col) {
		//Debug.Log (name + " triggered " + col.gameObject.name);
		GameObject obj = col.gameObject;

		Projectile projectile = obj.GetComponent<Projectile> ();
		if (projectile != null) {
			if (health.DealingDamage(projectile.damage)) {
				Destroy(gameObject);
			}
			Destroy(obj);
		}
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

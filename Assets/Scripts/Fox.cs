using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Attacker))]
public class Fox : MonoBehaviour {

	Animator anim;
	Attacker att;

	void Start() {
		anim = GetComponent<Animator> ();
		att = GetComponent<Attacker> ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		GameObject obj = col.gameObject;

		if (!obj.GetComponent<Defender> ()) {
			return;
		}

		if (obj.GetComponent<Stone> ()) {
			anim.SetTrigger ("IsTrigger");
		} else {
			anim.SetBool("IsAttacking", true);
			att.Attack(obj);
		}
	}
}

using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Attacker))]
public class Lizard : MonoBehaviour {
	
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
		
		anim.SetBool("IsAttacking", true);
		att.Attack(obj);
	}
}

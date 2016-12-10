using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Attackers))]
public class Lizard : MonoBehaviour {
	
	Animator anim;
	Attackers att;
	
	void Start() {
		anim = GetComponent<Animator> ();
		att = GetComponent<Attackers> ();
	}
	
	void OnTriggerEnter2D(Collider2D col) {
		GameObject obj = col.gameObject;
		
		if (!obj.GetComponent<Defenders> ()) {
			return;
		}
		
		anim.SetBool("IsAttacking", true);
		att.Attack(obj);
	}
}

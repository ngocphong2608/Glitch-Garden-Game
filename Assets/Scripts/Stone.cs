using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	void OnTriggerStay2D(Collider2D col) {
		Attacker att = col.gameObject.GetComponent<Attacker> ();
		if (att != null) {
			anim.SetTrigger("underAttacking trigger");
		}
	}
}

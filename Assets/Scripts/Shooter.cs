using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;

	private GameObject projectileParent;

	void Start() {
		projectileParent = GameObject.Find ("Projectiles");
		if (projectileParent == null) {
			projectileParent = new GameObject("Projectiles");
		}
	}

	public void FireGun() {
		GameObject obj = Instantiate (projectile, gun.transform.position, Quaternion.identity) as GameObject;
		obj.transform.parent = projectileParent.transform;
	}
}

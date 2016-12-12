using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, projectileParent, gun;

	public void FireGun() {
		GameObject obj = Instantiate (projectile, gun.transform.position, Quaternion.identity) as GameObject;
		obj.transform.parent = projectileParent.transform;
	}
}

using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{

	public GameObject projectile, gun;

	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;

	void Start ()
	{
		projectileParent = GameObject.Find ("Projectiles");
		if (projectileParent == null) {
			projectileParent = new GameObject ("Projectiles");
		}

		animator = gameObject.GetComponent<Animator> ();

		SetMyLaneSpawner();
	}

	void Update() {
		if (IsAttackerHeadInLane ()) {
			animator.SetBool ("IsAttacking", true);
		} else {
			animator.SetBool ("IsAttacking", false);
		}
	}

	void SetMyLaneSpawner() {
		Spawner[] spawners = GameObject.FindObjectsOfType<Spawner> ();

		foreach (Spawner spawner in spawners) {
			if (spawner.transform.position.y == transform.position.y) {
				myLaneSpawner = spawner;
				return;
			}
		}

		Debug.LogError(name + "Can't find the lane spawner");
	}

	bool IsAttackerHeadInLane() {
		if (myLaneSpawner == null || myLaneSpawner.transform.childCount <= 0) {
			return false;
		} else {
			// If there are attackers, are they ahead?
			foreach (Transform att in myLaneSpawner.transform) {
				if (att.transform.position.x > transform.position.x)
					return true;
			}

			// Attackers in lane but behind us
			return false;
		}
	}

	public void FireGun ()
	{
		GameObject obj = Instantiate (projectile, gun.transform.position, Quaternion.identity) as GameObject;
		obj.transform.parent = projectileParent.transform;
	}
}

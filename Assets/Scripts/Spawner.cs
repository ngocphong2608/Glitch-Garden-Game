using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] attPrefs;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject attacker in attPrefs) {
			if (IsTimeToSpawn(attacker)) {
				Spawn(attacker);
			}
		}
	}

	private bool IsTimeToSpawn(GameObject att) {
		Attacker attacker = att.GetComponent<Attacker> ();

		float meanSpawnDelay = attacker.seenEverySecond;
		float spawnPerSecond = 1 / meanSpawnDelay;

		if (Time.deltaTime > meanSpawnDelay) {
			Debug.Log ("Spawn rate capped by frame rate");
		}

		float threshold = spawnPerSecond * Time.deltaTime / 5f;

		if (Random.value < threshold) {
			return true;
		}

		return false;
	}

	void Spawn (GameObject attacker)
	{
		GameObject obj = Instantiate (attacker, this.transform.position, Quaternion.identity) as GameObject;
		obj.transform.parent = this.transform;
	}
}

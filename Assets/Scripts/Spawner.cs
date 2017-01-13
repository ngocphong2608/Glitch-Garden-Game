using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

	public GameObject[] attPrefs;
	public float[] seenEverySeconds;
	private GameTime gameTime;
	// three hard level: 0, 1, 2
	private bool[] incHard;

	// Use this for initialization
	void Start ()
	{
		gameTime = FindObjectOfType<GameTime> ();
		incHard = new bool[3];
	}
	
	// Update is called once per frame
	void Update ()
	{
		//if (attPrefs.Length > 0)
		//	IncHardLevel ();

		for (int i = 0; i < attPrefs.Length; i++) {
			if (IsTimeToSpawn (i)) {
				Spawn (i);
			}
		}
	}

	void IncHardLevel() {
		float part = gameTime.GetTimeValue () * 4;
		if (incHard [0] == false && part >= 1) {
			IncAllSpawnTime (2);
			incHard [0] = true;
			
			//Debug.Log (gameTime.GetTimeValue () * 4 + " seconds, " + 1);
		} else if (incHard [1] == false && part >= 2) {
			IncAllSpawnTime (2);
			incHard [1] = true;
			
			//Debug.Log (gameTime.GetTimeValue () * 4 + " seconds, " + 2);
		} else if (incHard [2] == false && part >= 3) {
			IncAllSpawnTime (2);
			incHard [2] = true;
			
			//Debug.Log (gameTime.GetTimeValue () * 4 + " seconds, " + 3);
		}
	}

	void IncAllSpawnTime (int d)
	{
		for (int i = 0; i < seenEverySeconds.Length; i++) {
			seenEverySeconds [i] -= d;
		}
	}

	private bool IsTimeToSpawn (int pos)
	{
		float meanSpawnDelay = seenEverySeconds [pos];
		float spawnPerSecond = 1 / meanSpawnDelay;
		
		if (Time.deltaTime > meanSpawnDelay) {
			Debug.Log ("Spawn rate capped by frame rate");
		}
		
		float threshold = spawnPerSecond * Time.deltaTime;
		
		return (Random.value < threshold);
	}

	void Spawn (int pos)
	{
		GameObject obj = Instantiate (attPrefs [pos], this.transform.position, Quaternion.identity) as GameObject;
		obj.transform.parent = this.transform;
	}


}

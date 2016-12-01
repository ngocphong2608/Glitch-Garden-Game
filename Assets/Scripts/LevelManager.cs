﻿using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float autoLoadingDelay;

	void Start() {
		if (autoLoadingDelay != 0) {
			Invoke ("LoadNextLevel", autoLoadingDelay);
		}
	}

	public void LoadLevel(string name) {
		Debug.Log ("Level load requested for: " + name);
		Application.LoadLevel (name);
	}

	public void QuitRequest(){
		Debug.Log ("I want to quit!");
		Application.Quit ();
	}

	public void LoadNextLevel() {
		Application.LoadLevel (Application.loadedLevel + 1);
	}
}
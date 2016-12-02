using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	public AudioClip[] clips;

	AudioSource audioSource;
	
	void Awake() {
		audioSource = GetComponent<AudioSource> ();
		DontDestroyOnLoad (gameObject);
	}

	void OnLevelWasLoaded(int level) {
		AudioClip thisLevelMusic = clips [level];
		//Debug.Log ("Level was loaded: " + thisLevelMusic);

		if (thisLevelMusic == audioSource.clip)
			return;

		if (thisLevelMusic) {
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play ();
		}

	}
}

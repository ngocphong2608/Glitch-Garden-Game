using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public LevelManager levelManager;
	public Slider volumeSlider;
	public Slider diffSlider;

	private MusicPlayer musicPlayer;


	// Use this for initialization
	void Start () {
		musicPlayer = GameObject.FindObjectOfType<MusicPlayer> ();

		volumeSlider.value = PlayerPrefsManager.GetMasterVolume ();
		diffSlider.value = PlayerPrefsManager.GetDifficulty ();
	}

	void Update() {
		musicPlayer.SetVolume (volumeSlider.value);
	}
	
	public void SaveOnExit() {
		PlayerPrefsManager.SetMasterVolume (volumeSlider.value);
		PlayerPrefsManager.SetDifficulty (diffSlider.value);
		levelManager.LoadLevel ("01a_Start");
	}

	public void SetDefault() {
		volumeSlider.value = 0.5f;
		diffSlider.value = 2f;
	}
}


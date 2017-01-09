using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelController : MonoBehaviour {

	private Button[] levels;
	private GameObject gameLevel;

	// Use this for initialization
	void Start () {
		gameLevel = GameObject.Find ("Game Levels");
		levels = new Button[gameLevel.transform.childCount];
		for (int i = 0; i < gameLevel.transform.childCount; i++) {
			levels.SetValue(gameLevel.transform.GetChild(i).GetComponent<Button>(), i);
		}

		PlayerPrefsManager.UnlockLevel (0);
		//Debug.Log (levels.Length);
		for (int i = 0; i < levels.Length; i++) {
			if (PlayerPrefsManager.IsLevelUnlocked(i))
				levels[i].interactable = true;
		}
	}

	[ContextMenu ("Delete All Level")]
	void DeleteAllLevel() {
		PlayerPrefsManager.DeleteAll ();
	}
}

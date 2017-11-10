using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public static LevelManager instance = null;
	ScoreKeeper scoreKeeper = null;
	public float autoLoadLevelTimer;

	void Awake () {
		if (instance == null) {
			instance = this;
		}
		else {
			Debug.LogWarning("Duplicate Level Manager Destroyed");
			Destroy(this.gameObject);
		}

		DontDestroyOnLoad(this.gameObject);
	}

	void Start () {
		if (autoLoadLevelTimer <= 0) {
			Debug.LogError("Auto Load Level Timer disabled.  Must be greater than zero seconds.");
		}
		else {
			Invoke("LoadNextLevel", autoLoadLevelTimer);
		}
	}

	public void LoadLevel (int levelIndex) {
		SceneManager.LoadScene(levelIndex);
		ClearScoreAtMenu();
	}

	public void LoadNextLevel () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		ClearScoreAtMenu();
	}

	void ClearScoreAtMenu () {
		if (SceneManager.GetActiveScene().buildIndex == 1) {
			ScoreKeeper.ClearScore();
		}
	}
}

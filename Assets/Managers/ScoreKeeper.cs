using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
	
	public static ScoreKeeper instance = null;
	static int currentScore = 0;

	void Awake () {
		if (instance == null) {
			instance = this;
		}
		else {
			Debug.LogWarning("Duplicate Score Keeper Destroyed");
			Destroy(this.gameObject);
		}

		DontDestroyOnLoad(this.gameObject);
	}

	public static void AddScore (int anAmount) {
		currentScore += anAmount;
	}

	public static int GetScore () {
		return currentScore;
	}

	public static void ClearScore () {
		currentScore = 0;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	public Text scoreText;
	static int currentScore = 0;

	void Start () {
		UpdateScoreText();
	}

	public void AddScore (int anAmount) {
		currentScore += anAmount;
		UpdateScoreText();
	}

	public int GetScore () {
		return currentScore;
	}

	public void ClearScore () {
		currentScore = 0;
		UpdateScoreText();
	}

	void UpdateScoreText () {
		scoreText.text = "Score: " + currentScore;
	}
}

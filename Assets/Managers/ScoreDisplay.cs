using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	Text scoreText;

	void Start () {
		scoreText = GetComponent<Text>();
	}
	
	void Update () {
		scoreText.text = "Score: " + ScoreKeeper.GetScore();
	}
}

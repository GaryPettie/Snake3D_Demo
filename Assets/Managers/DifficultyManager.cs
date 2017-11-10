using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour {

	void Start () {
		PlayerMovement.difficulty = 1;
	}

	public void ChangeDifficulty (int level) {
		PlayerMovement.difficulty = level;
	}
}

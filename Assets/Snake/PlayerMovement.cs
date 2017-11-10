using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	enum Moving { UP, DOWN, LEFT, RIGHT };
	public enum Difficulty { EASY, MEDUIM, HARD };

	public static int difficulty;
	public GameObject bodyPrefab;
	public List<GameObject> Snake = new List<GameObject>();
	public float[] moveTick = { 0.2f, 0.1f, 0.05f};
	public float offsetDistance;
	
	float countdown;
	Moving moving = Moving.UP;

	void Start () {
		Snake.Add(this.gameObject);
	}

	void Update () {
		CheckForInput();
		UpdateCountdown();

		if(countdown <= 0) {
			transform.position = transform.position + transform.forward * (1 + offsetDistance);
			FollowLastBodyPart();
			countdown = moveTick[difficulty];
		}
	}

	void UpdateCountdown () {
		countdown -= Time.deltaTime;
	}

	void CheckForInput () {
		if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) {
			if (moving != Moving.DOWN) {
				moving = Moving.UP;
				transform.rotation = Quaternion.Euler(0, 0, 0);
			}
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
			if (moving != Moving.RIGHT) {
				moving = Moving.LEFT;
				transform.rotation = Quaternion.Euler(0, -90, 0);
			}
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) {
			if (moving != Moving.UP) {
				moving = Moving.DOWN;
				transform.rotation = Quaternion.Euler(0, 180, 0);
			}
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
			if (moving != Moving.LEFT) {
				moving = Moving.RIGHT;
				transform.rotation = Quaternion.Euler(0, 90, 0);
			}
		}
	}

	void GrowSnake () {
		//BUG The first body part that gets added overlaps with the head. 
		Transform lastPart = Snake[Snake.Count - 1].transform;
		Vector3 newPos = lastPart.position - (lastPart.forward * (1 + offsetDistance));
		GameObject newPart = Instantiate(bodyPrefab, newPos, transform.rotation);
		Snake.Add(newPart);
	}

	void FollowLastBodyPart () {
		for (int i = Snake.Count - 1; i > 0; i--) {
			Snake[i].transform.position = Snake[i - 1].transform.position;
			Snake[i].transform.rotation = Snake[i - 1].transform.rotation;
			Debug.Log(Snake.Count);
			if (i == 1) {
				Snake[i].transform.position = transform.position - transform.forward * (1 + offsetDistance);
			}
		}
	}

	void OnTriggerEnter (Collider other) {
		string tag = other.gameObject.tag;
		if (tag == "Wall" || tag == "Body") {
			KillSnake();
		} 
		else if (other.gameObject.tag == "Pickup") {
			ScoreKeeper.AddScore(other.gameObject.GetComponent<Pickup>().points);
			Destroy(other.gameObject);
			GrowSnake();
		}
	}

	void KillSnake () {
		foreach (GameObject part in Snake) {
			Destroy(part);
		}
		LevelManager.instance.LoadNextLevel();	
	}
}

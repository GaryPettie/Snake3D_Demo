using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawn : MonoBehaviour {

	public Vector3 arenaDimensions;
	public GameObject[] pickupPrefab;
	public float spawnRate;
	public float lifeTime;
	public GameObject badPickupPrefab;
	public float badSpawnRate;

	float countdown = 0;


	void Start () {
		InvokeRepeating("CreateBadPickup", 0.01f, badSpawnRate);
	}
	
	void Update () {
		UpdateCountdown();
		CreateNewPickup();
	}

	void UpdateCountdown () {
		countdown -= Time.deltaTime;
	}

	void CreateNewPickup () {
		if (countdown <= 0) {
			int pickupNum = Random.Range(0, pickupPrefab.Length);
			Vector3 randPos = new Vector3(Random.Range(-arenaDimensions.x, arenaDimensions.x), 
											pickupPrefab[pickupNum].transform.position.y, 
											Random.Range(-arenaDimensions.z, arenaDimensions.z));
			GameObject pickup = Instantiate(pickupPrefab[pickupNum], randPos, Quaternion.identity, transform);
			Destroy(pickup, lifeTime);
			countdown = spawnRate;
		}
	}

	void CreateBadPickup () {
		Vector3 randPos = new Vector3(Random.Range(-arenaDimensions.x, arenaDimensions.x),
											badPickupPrefab.transform.position.y,
											Random.Range(-arenaDimensions.z, arenaDimensions.z));
		GameObject pickup = Instantiate(badPickupPrefab, randPos, Quaternion.identity, transform);
	}
}

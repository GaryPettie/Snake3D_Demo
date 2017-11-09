using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawn : MonoBehaviour {

	public GameObject[] pickupPrefab;
	public float spawnRate;
	public float lifeTime;
	public Vector3 arenaDimensions;

	float countdown = 0;


	void Start () {
				
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
			GameObject pickup = Instantiate(pickupPrefab[pickupNum], randPos, Quaternion.identity);
			Destroy(pickup, lifeTime);
			countdown = spawnRate;
		}
	}
}

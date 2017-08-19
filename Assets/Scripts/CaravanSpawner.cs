using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaravanSpawner : MonoBehaviour {

	[SerializeField]
	GameObject caravanPrefab;

	[SerializeField]
	List<GameObject> SpawnPoints;

	void SpawnCaravan(Vector3 position, Quaternion rotation, int playerId)
	{
		var newCaravan = GameObject.Instantiate(caravanPrefab, position, rotation);
		newCaravan.GetComponent<CaravanInput>().SetPlayer(playerId);
		// whacky way of setting the viewport for splitscreen
		newCaravan.GetComponentInChildren<Camera>().rect = new Rect(0.5f - 0.5f * (playerId - 1), 0, 0.5f, 1);

		// Add caravan setup here
	}

	// Use this for initialization
	void Start () {
		SpawnCaravan(SpawnPoints[0].transform.position, SpawnPoints[0].transform.rotation, 1);
		SpawnCaravan(SpawnPoints[1].transform.position, SpawnPoints[1].transform.rotation, 2);
	}
}

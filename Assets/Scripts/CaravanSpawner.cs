﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaravanSpawner : MonoBehaviour {

	[SerializeField]
	GameObject caravanPrefab;

	[SerializeField]
	List<GameObject> SpawnPoints;

    List<GameObject> caravans;

	GameObject SpawnCaravan(Transform transform, int playerId)
	{
        
		var newCaravan = GameObject.Instantiate(caravanPrefab, transform.position, transform.rotation);
		newCaravan.GetComponent<CaravanInput>().SetPlayer(playerId);

        Debug.Log("Caravan " + playerId + " Rotation: " + newCaravan.transform.rotation.eulerAngles);

        // whacky way of setting the viewport for splitscreen
        newCaravan.GetComponentInChildren<Camera>().rect = new Rect(0.5f - 0.5f * (playerId - 1), 0, 0.5f, 1);

        // Add caravan setup here
        newCaravan.transform.rotation.Set(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);

        GameManager.instance.players[playerId - 1].SetAbilityController(newCaravan.GetComponent<AbilityController>());

        // Disable input
        newCaravan.GetComponent<CaravanInput>().DisableInput();
        
        return newCaravan;
    }

	// Use this for initialization
	public void Initialize () {
        //Debug.Log(SpawnPoints[0].transform.rotation.eulerAngles);
        caravans = new List<GameObject>();
		caravans.Add(SpawnCaravan(SpawnPoints[0].transform, 1));
        caravans.Add(SpawnCaravan(SpawnPoints[1].transform, 2));
	}

     void OnDestroy()
    {
        for (int i = 0; i < caravans.Count; i ++)
        {
            Destroy(caravans[i]);
        }
    }

    public void EnableCaravanInput()
    {
        for (int i = 0; i < 2; i ++)
        {
            caravans[i].GetComponent<CaravanInput>().EnableInput();
        }
    }
}

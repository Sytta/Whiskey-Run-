using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaravanSpawner : MonoBehaviour
{
	[SerializeField]
	GameObject caravanPrefab;

	[SerializeField]
	List<GameObject> SpawnPoints;

    public List<GameObject> caravans { get; set; }

	void Start()
	{

	}

	GameObject SpawnCaravan(Transform transform, int playerId)
	{
        
		var newCaravan = GameObject.Instantiate(caravanPrefab, transform.position, transform.rotation);
		newCaravan.GetComponent<CaravanInput>().SetPlayer(playerId);

        Debug.Log("Caravan " + playerId + " Rotation: " + newCaravan.transform.rotation.eulerAngles);

        // whacky way of setting the viewport for splitscreen
        // 1 -> 0
        // 2 -> 0.5
        newCaravan.GetComponentInChildren<Camera>().rect = new Rect(0.5f * (playerId - 1), 0, 0.5f, 1);

        // Add caravan setup here
        newCaravan.transform.rotation.Set(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);

        GameManager.instance.players[playerId - 1].SetAbilityController(newCaravan.GetComponent<AbilityController>());

        // Disable input
        newCaravan.GetComponent<CaravanInput>().DisableInput();

		SpawnCaravanInventory(playerId, newCaravan.GetComponentInChildren<CaravanInventoryView>());

        return newCaravan;
    }

	// Use this for initialization
	public void Initialize ()
	{
		DestroyCaravans ();

        caravans = new List<GameObject>();
        for (int i = 0; i < GameManager.instance.nbPlayers; i++)
        {
            caravans.Add(SpawnCaravan(SpawnPoints[i].transform, GameManager.instance.players[i].id));
        }
	}

     public void DestroyCaravans()
    {
		if (caravans == null)
			return;
		
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

    public void DisableCaravanInput(int playerId)
    {
        caravans[playerId].GetComponent<CaravanInput>().DisableInput();
        Debug.Log("Disabled input of Player " + (playerId + 1));
        // Slowly come to a stop
        caravans[playerId].GetComponent<MotionControl>().AccelerateToward(new Vector3(0, 0, 0));
    }

	private void SpawnCaravanInventory(int playerId, CaravanInventoryView caravanItemView)
	{
		if(caravanItemView == null)
		{
			return;
		}

		// TODO: spawn jalapenos

		// spawn crates last so they are last to go
		for(int i = 0; i < GameManager.instance.players[playerId - 1].nbCrates; ++i)
		{
			caravanItemView.AddItem(CaravanInventoryView.ItemTypes.Crate);
		}
		
	}
}

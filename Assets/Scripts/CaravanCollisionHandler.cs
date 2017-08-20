using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaravanCollisionHandler : MonoBehaviour {

	PlayerInfo owner;
	[SerializeField]
	CaravanInventoryView inventoryView;

	public void SetOwner(int playerId)
	{
		owner = GameManager.instance.players[playerId - 1];
	}

	private void OnTriggerEnter(Collider other)
	{
		var invWreck = other.GetComponent<InventoryWrecker>();
		if (invWreck)
		{
			for (int i = 0; i < invWreck.ItemsToDropOnCollision; i++)
			{
				Mathf.Max(owner.nbCrates -= 1, 0);
				inventoryView.DropItem(CaravanInventoryView.ItemTypes.Crate);
			}
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaravanCollisionHandler : MonoBehaviour {

	PlayerInfo owner;
	[SerializeField]
	CaravanInventoryView inventoryView;
	[SerializeField]
	AbilityController caravanAbilities;


	public void SetOwner(int playerId)
	{
		owner = GameManager.instance.players[playerId - 1];
	}

	private void OnTriggerEnter(Collider other)
	{
		var invWreck = other.GetComponent<InventoryWrecker>();
		var immunities = caravanAbilities.gameObject.GetComponent<ImmunityComponent>();
		if (invWreck)
		{
			for (int i = 0; i < invWreck.ItemsToDropOnCollision; i++)
			{
				if(immunities && immunities.VerifyCanUse())
				{
                    immunities.Use(Vector3.zero);
                }
				else
				{
                    if (owner.Abilities["Crate"] > 0)
                    {
                        Mathf.Max(owner.Abilities["Crate"] -= 1, 0);
                        inventoryView.DropItem(CaravanInventoryView.ItemTypes.Crate);
                    }
				}
			}
		}
	}

}

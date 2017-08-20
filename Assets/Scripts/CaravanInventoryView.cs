using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaravanInventoryView : MonoBehaviour {
	[SerializeField]
	List<Transform> itemPositions;

	public void AddItem()
	{
		// TODO: Get next free item position and spawn item
	}

	public void RemoveItem()
	{
		// TODO: find item position and remove it from caravan
	}

	public void DropItem()
	{
		// TODO: remove the item while spawning a physics version that falls off the caravan.
	}
}

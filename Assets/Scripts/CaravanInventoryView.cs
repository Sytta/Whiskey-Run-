using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaravanInventoryView : MonoBehaviour {
	[SerializeField]
	List<Transform> itemPositions; // Only used for item positions
	[SerializeField]
	Transform ItemDropSpawnPoint;
	[Header("Prefabs")]
	[SerializeField]
	GameObject cratePrefab;
	[SerializeField]
	GameObject jalapenosPrefap;

	Dictionary<ItemTypes, List<Transform>> slotsByItemType = new Dictionary<ItemTypes, List<Transform>>();

	public enum ItemTypes
	{
		Crate,
		Jalapenos
	}

	private void Start()
	{
		slotsByItemType.Add(ItemTypes.Crate, new List<Transform>());
		slotsByItemType.Add(ItemTypes.Jalapenos, new List<Transform>());
	}

	public void AddItem(ItemTypes itemType)
	{
		var slot = getFreeInventorySlot();
		var item = getItemPrefab(itemType);
		if (slot && item)
		{
			Instantiate(item, slot, false);
			slotsByItemType[itemType].Add(slot);
		}
	}

	/// <summary>
	/// Remove an item from inside the cart
	/// </summary>
	/// <param name="itemType">the type of item to remove</param>
	/// <returns>true if item was removed</returns>
	public bool RemoveItem(ItemTypes itemType)
	{
		if(slotsByItemType[itemType].Count > 0)
		{
			Destroy(slotsByItemType[itemType][0].GetChild(0).gameObject);
			slotsByItemType[itemType].RemoveAt(0);
			return true;
		}
		return false;
	}

	public void DropItem(ItemTypes itemType)
	{
		var item = getItemPrefab(itemType);
		if (item != null && RemoveItem(itemType))
		{
			var droppedItem = Instantiate(item, ItemDropSpawnPoint.position, ItemDropSpawnPoint.rotation);
			var itemPhysics = droppedItem.GetComponent<Rigidbody>();
			if (itemPhysics)
			{
				itemPhysics.isKinematic = false;
				itemPhysics.useGravity = true;
				itemPhysics.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);
			}
		}
	}

	GameObject getItemPrefab(ItemTypes type)
	{
		switch (type)
		{
			case ItemTypes.Crate:
				return cratePrefab;
			case ItemTypes.Jalapenos:
				return jalapenosPrefap;
			default:
				return null;
		}
	}

	Transform getFreeInventorySlot()
	{
		foreach(var itemSlot in itemPositions)
		{
			if(itemSlot.childCount == 0)
			{
				return itemSlot;
			}
		}
		return null;
	}

	/// <summary>
	/// Using this for debug only, remove asap
	/// </summary>
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			AddItem(ItemTypes.Crate);
		}
		if (Input.GetKeyDown(KeyCode.C))
		{
			RemoveItem(ItemTypes.Crate);
		}
		if (Input.GetKeyDown(KeyCode.X))
		{
			DropItem(ItemTypes.Crate);
		}
	}
}

﻿using System;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
	[SerializeField] GameObject shopItemPrefab;
	[SerializeField] GameObject[] playerShop;
	[SerializeField] AbilitiesDatabase database;

	void Start()
	{
		for (int i = 0; i < playerShop.Length; i++)
		{
			int playerId = i;

			for (int j = 0; j < database.Abilities.Count; j++)
			{
				int abilityIndex = j;

				GameObject item = Instantiate (shopItemPrefab, playerShop [i].transform);
				item.GetComponent<ShopItem> ().SetName (database.Abilities [j].Name);
				item.GetComponent<ShopItem> ().SetDescription (database.Abilities [j].Description);
				item.GetComponent<Button> ().onClick.AddListener (delegate
				{
					PurchaseItem (playerId, database.Abilities [abilityIndex].Name, "");
				});
			}
		}
	}

	void PurchaseItem(int playerId, string ability, string input)
	{
		Debug.Log ("Purchased " + ability + " by player " + playerId);
		GameManager.instance.players [playerId].PurchaseAbility (ability, input);
	}
}


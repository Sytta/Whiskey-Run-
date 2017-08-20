﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
	[SerializeField] GameObject shopItemPrefab;
	[SerializeField] Text[] playerCurrency;
	[SerializeField] GameObject[] playerShop;
	List<List<ShopItem>> items;
	int[] selectedItem;
	bool[] allowMovement;

	void Start()
	{
		UpdateCurrency ();

		items = new List<List<ShopItem>> (GameManager.instance.nbPlayers);
		for (int i = 0; i < GameManager.instance.nbPlayers; i++)
		{
			items.Add(new List<ShopItem> ());
		}

		for (int i = 0; i < playerShop.Length; i++)
		{
			int playerId = i;

			for (int j = 0; j < GameManager.instance.AbilitiesDatabase.Count; j++)
			{
				if (GameManager.instance.AbilitiesDatabase [j].Purchasable)
				{
					int abilityIndex = j;

					GameObject item = Instantiate (shopItemPrefab, playerShop [i].transform);
					item.name = GameManager.instance.AbilitiesDatabase [j].Name;

					items [i].Add (item.GetComponent<ShopItem> ());
					item.GetComponent<ShopItem> ().SetInfo
					(
						GameManager.instance.AbilitiesDatabase [j].Name,
						GameManager.instance.AbilitiesDatabase [j].Description,
						GameManager.instance.AbilitiesDatabase [j].Cost,
						GameManager.instance.AbilitiesDatabase [j].Image,
						GameManager.instance.AbilitiesDatabase [j].Controls,
						GameManager.instance.AbilitiesDatabase [j].Locked
					);

					item.GetComponent<Button> ().onClick.AddListener (delegate
					{
						PurchaseItem (playerId, GameManager.instance.AbilitiesDatabase [abilityIndex].Id);
					});
				}
			}
		}

		selectedItem = new int[GameManager.instance.nbPlayers];
		allowMovement = new bool[GameManager.instance.nbPlayers];
		for (int i = 0; i < GameManager.instance.nbPlayers; i++)
		{
			selectedItem [i] = 0;
			allowMovement [i] = true;
		}
		EnableSelectedDisplay ();
	}

	void Update()
	{
		for (int i = 0; i < GameManager.instance.nbPlayers; i++)
		{
			if (Input.GetAxis ("Vertical_P" + (i + 1).ToString ()) > 0.0f)
			{
				if (allowMovement[i])
				{
					allowMovement[i] = false;
					DecrementSelected (i);
				}
			}
			else if (Input.GetAxis ("Vertical_P" + (i + 1).ToString ()) < 0.0f)
			{
				if (allowMovement[i])
				{
					allowMovement[i] = false;
					IncrementSelected (i);
				}
			}
			else
			{
				allowMovement [i] = true;
			}
		}
	}

	void UpdateCurrency()
	{
		for (int i = 0; i < playerCurrency.Length; i++)
		{
			Debug.Log (i + " " + GameManager.instance.players [i].money + "$");
			playerCurrency [i].text = GameManager.instance.players [i].money.ToString () + "$";
		}
	}

	#region ItemSelection
	void IncrementSelected(int playerIndex)
	{
		if (selectedItem [playerIndex] < (items [playerIndex].Count - 1))
		{
			DisableSelectedDisplay ();
			selectedItem [playerIndex]++;
			EnableSelectedDisplay ();
		}
	}

	void DecrementSelected(int playerIndex)
	{
		if (selectedItem [playerIndex] > 0)
		{
			DisableSelectedDisplay ();
			selectedItem [playerIndex]--;
			EnableSelectedDisplay ();
		}
	}

	void EnableSelectedDisplay()
	{
		for (int i = 0; i < GameManager.instance.nbPlayers; i++)
		{
			items [i] [selectedItem [i]].EnableSelected ();
		}
	}

	void DisableSelectedDisplay()
	{
		for (int i = 0; i < GameManager.instance.nbPlayers; i++)
		{
			items [i] [selectedItem [i]].DisableSelected ();
		}
	}
	#endregion

	void PurchaseItem(int playerId, string ability)
	{
		Debug.Log ("Purchased " + ability + " by player " + playerId);
		GameManager.instance.players [playerId].PurchaseAbility (ability);
		UpdateCurrency ();
	}
		
	public void OpenPanel()
	{
		this.gameObject.SetActive (true);
	}

	public void ClosePanel()
	{
		this.gameObject.SetActive (false);
	}
}


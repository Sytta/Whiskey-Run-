using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
	[SerializeField] GameObject shopItemPrefab;
	[SerializeField] Text[] playerCurrency;
	[SerializeField] GameObject[] playerReady;
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
			for (int j = 0; j < GameManager.instance.AbilitiesDatabase.Count; j++)
			{
				if (GameManager.instance.AbilitiesDatabase [j].Purchasable)
				{
					GameObject item = Instantiate (shopItemPrefab, playerShop [i].transform);
					item.name = GameManager.instance.AbilitiesDatabase [j].Name;

					items [i].Add (item.GetComponent<ShopItem> ());
					item.GetComponent<ShopItem> ().SetInfo
					(
						GameManager.instance.AbilitiesDatabase [j].Id,
						GameManager.instance.AbilitiesDatabase [j].Name,
						GameManager.instance.AbilitiesDatabase [j].Description,
						GameManager.instance.AbilitiesDatabase [j].Cost,
						GameManager.instance.AbilitiesDatabase [j].Image,
						GameManager.instance.AbilitiesDatabase [j].Controls,
						GameManager.instance.AbilitiesDatabase [j].Locked
					);
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
		#region Move
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
		#endregion
		#region Buy
		if (Input.GetKeyDown(KeyCode.Joystick1Button0)) // "A" button
		{
			if (VerifyCanPurchase(0, items[0][selectedItem[0]].AbilityId))
			{
				PurchaseItem(0, items[0][selectedItem[0]].AbilityId);
			}
			else
			{
				Debug.Log("Cannot purchase item : " + items[0][selectedItem[0]].AbilityId);
			}
		}
		if (Input.GetKeyDown(KeyCode.Joystick2Button0)) // "A" button
		{
			if (VerifyCanPurchase(1, items[1][selectedItem[1]].AbilityId))
			{
				PurchaseItem(1, items[1][selectedItem[1]].AbilityId);
			}
			else
			{
				Debug.Log("Cannot purchase item : " + items[1][selectedItem[1]].AbilityId);
			}
		}
		#endregion
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

	bool VerifyCanPurchase(int playerId, string ability)
	{
		Ability ab = GameManager.instance.AbilitiesDatabase.Find (x => x.Id == ability);
		if (ab == null)
			return false;
		if (ab.Locked)
			return false;
		if (ab.Cost > GameManager.instance.players [playerId].money)
			return false;

		return true;
		
	}

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

	public void SetReady(int playerIndex)
	{
		playerShop [playerIndex].SetActive (false);
		playerReady [playerIndex].SetActive (true);
	}
}


using System;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
	[SerializeField] GameObject shopItemPrefab;
	[SerializeField] GameObject[] playerShop;

	void Start()
	{
		for (int i = 0; i < playerShop.Length; i++)
		{
			int playerId = i;

			for (int j = 0; j < GameManager.instance.AbilitiesDatabase.Count; j++)
			{
				int abilityIndex = j;

				GameObject item = Instantiate (shopItemPrefab, playerShop [i].transform);
				item.name = GameManager.instance.AbilitiesDatabase [j].Name;

				item.GetComponent<ShopItem> ().SetInfo
				(
					GameManager.instance.AbilitiesDatabase [j].Name,
					GameManager.instance.AbilitiesDatabase [j].Description,
					GameManager.instance.AbilitiesDatabase [j].Cost,
					GameManager.instance.AbilitiesDatabase [j].Image
				);

				item.GetComponent<Button> ().onClick.AddListener (delegate
				{
					PurchaseItem (playerId, GameManager.instance.AbilitiesDatabase [abilityIndex].Name, "");
				});
			}
		}
	}

	void PurchaseItem(int playerId, string ability, string input)
	{
		Debug.Log ("Purchased " + ability + " by player " + playerId);
		GameManager.instance.players [playerId].PurchaseAbility (ability, input);
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


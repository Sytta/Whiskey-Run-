using System;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
	[SerializeField] public GameObject MainMenuPrefab;
	[SerializeField] public GameObject RacingUI;
	[SerializeField] public GameObject Shop;
	[SerializeField] public GameObject ShopItem;
	[SerializeField] public GameObject ScoreBoard;
	[SerializeField] public GameObject AbilitySlot;

	void Start()
	{
		DontDestroyOnLoad (this.gameObject);
	}
}


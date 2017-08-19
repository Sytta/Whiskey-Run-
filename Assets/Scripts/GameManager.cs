using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public int nbPlayers = 2;
	[HideInInspector] public PlayerInfo[] players;

	[SerializeField] public List<Ability> AbilitiesDatabase;

	void Start()
	{
		players = new PlayerInfo[nbPlayers];

		for (int i = 0; i < nbPlayers; i++)
		{
			players [i] = new PlayerInfo ();
		}
	}
}


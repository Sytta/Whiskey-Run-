﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
    public int id { get; set; }
    public int money { get; set; }
    public int nbCrates { get; set; }
    public Dictionary<string, int> Abilities;
    AbilityController abilityController;

	public PlayerInfo(int id, int money, int nbCrates)
	{
        this.id = id;
        this.money = money;
        this.nbCrates = nbCrates;
		Abilities = new Dictionary<string, int> ();
	}

	public void PurchaseAbility (string ability)
	{
		money -= GameManager.instance.AbilitiesDatabase.Find(x => x.name == ability).Cost;
		if (Abilities.ContainsKey (ability))
		{
			Abilities [ability]++;
		}
		else
		{
			Abilities.Add (ability, 1);
		}
	}

    public void SetAbilityController(AbilityController ab)
    {
        abilityController = ab;

		// Debugging
		PurchaseAbility ("Nitro");

		abilityController.SetUpAbilities (Abilities);
    }

}

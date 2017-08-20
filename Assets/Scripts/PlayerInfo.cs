using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
    public int id { get; set; }
    public int money { get; set; }
    public int nbCrates { get; set; }
    public bool isWinner { get; set; }
    public int totalIncome { get; set; }
    public Dictionary<string, int> Abilities;
    AbilityController abilityController;

	public PlayerInfo(int id, int money, int nbCrates)
	{
        this.id = id;
        this.money = money;
        this.nbCrates = nbCrates;
		Abilities = new Dictionary<string, int> ();
        this.isWinner = false;
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

		abilityController.SetUpAbilities (Abilities);
    }
}

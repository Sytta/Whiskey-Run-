using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
    public int id { get; set; }
    public int money { get; set; }
    public bool isWinner { get; set; }
    public int totalIncome { get; set; }
    public Dictionary<string, int> Abilities;
    public AbilityController abilityController;

	public PlayerInfo(int id, int money)
	{
        this.id = id;
        this.money = money;
		Abilities = new Dictionary<string, int> ();
		Abilities.Add ("Crate", 5);
        this.isWinner = false;
		PurchaseAbility ("Lasso");
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
		ab.PlayerId = id;
		abilityController.SetUpAbilities (Abilities);
    }
		
}

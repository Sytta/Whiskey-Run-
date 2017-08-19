using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
    string id;
    int money;
    ArrayList crates;
    public Dictionary<string, int> Abilities;
    AbilityController abilityController;

	public PlayerInfo()
	{
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

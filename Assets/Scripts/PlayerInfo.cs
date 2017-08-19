using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
    string id;
    int money;
    ArrayList crates;
    public Dictionary<string, string> abilitiesInputMapping;
    AbilityController abilityController;

	public PlayerInfo()
	{
		abilitiesInputMapping = new Dictionary<string, string> ();
	}

	public void PurchaseAbility (string ability, string input)
	{
		money -= GameManager.instance.AbilitiesDatabase.Find(x => x.name == ability).Cost;
		abilitiesInputMapping.Add (input, ability);
	}

    public void SetAbilityController(AbilityController ab)
    {
        abilityController = ab;

		// Debugging
		PurchaseAbility ("Nitro", "X");

		abilityController.SetUpAbilities (abilitiesInputMapping);
    }

}

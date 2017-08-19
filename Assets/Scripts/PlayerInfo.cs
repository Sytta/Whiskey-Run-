using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
    public int id { get; set; }
    public int money { get; set; }
    public int nbCrates { get; set; }
    public Dictionary<string, string> abilitiesInputMapping;
    AbilityController abilityController;

	public PlayerInfo(int id, int money, int nbCrates)
	{
        this.id = id;
        this.money = money;
        this.nbCrates = nbCrates;
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

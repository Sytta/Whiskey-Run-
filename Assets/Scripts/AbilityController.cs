using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityController : MonoBehaviour
{
	[SerializeField] private Button testButton;
	[SerializeField] private AbilitiesDatabase database;
	//[SerializeField] private List<Ability> abilities;

	Dictionary<string, string> abilitiesInputMapping;
    // Reference to Playerinfo's ability selection
	Dictionary<string, BaseAbilityComponent> abilitiesComponents;

	void Start()
	{
		abilitiesInputMapping = new Dictionary<string, string> ();
		abilitiesComponents = new Dictionary<string, BaseAbilityComponent> ();
	}

    // Create all the abilities and call on setup on each of them
    void Setup()
	{
		
	}

	public void AddAbility(string name, string input = "")
	{
		if (abilitiesInputMapping.ContainsKey (input))
		{
			Debug.Log ("Error : Input is already associated with an ability");
			return;
		}

		abilitiesInputMapping.Add (input, name);
	}

	public void SetUpAbilities()
	{
		foreach (string ability in abilitiesInputMapping.Values)
		{
			Ability abil = database.Abilities.Find (x => x.Name == name);
			if (ability != null)
			{
				abilitiesComponents.Add(ability, abil.CreateComponent (this.gameObject));
			}
			else
			{
				Debug.Log ("Error : Couldn't find ability");
			}
		}
	}
}

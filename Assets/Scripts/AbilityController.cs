using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityController : MonoBehaviour
{
    // Reference to Playerinfo's ability selection
	Dictionary<string, BaseAbilityComponent> abilitiesComponents;

	void Start()
	{
		abilitiesComponents = new Dictionary<string, BaseAbilityComponent> ();
	}

    // Create all the abilities and call on setup on each of them
    void Setup()
	{
		
	}

	public void SetUpAbilities(Dictionary<string, int> abilitiesMapping)
	{
		if (abilitiesComponents == null)
			abilitiesComponents = new Dictionary<string, BaseAbilityComponent> ();
		
		foreach (string ability in abilitiesMapping.Keys)
		{
			Ability abil = GameManager.instance.AbilitiesDatabase.Find (x => x.Name == ability);
			Debug.Log (abilitiesComponents);
			if (ability != null)
			{
				abilitiesComponents.Add(ability, abil.CreateComponent (this.gameObject));
			}
			else
			{
				Debug.Log ("Error : Couldn't find ability");
			}
		}

		foreach (BaseAbilityComponent component in abilitiesComponents.Values)
		{
			component.OnSetup ();
		}
	}
}

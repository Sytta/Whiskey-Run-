using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityController : MonoBehaviour
{
	public int PlayerId;
    // Reference to Playerinfo's ability selection
	public List<BaseAbilityComponent> components;

	void Start()
    { 
	}

	void Update()
	{
		foreach (BaseAbilityComponent comp in components)
		{
			foreach (string button in comp.Ability.Input)
			{
                
				if (Input.GetAxis (button + "_P" + PlayerId.ToString ()) > 0.0f)
				{
					comp.Use(new Vector3(0.0f, 0.0f, 0.0f));
				}
			}
		}
	}

    // Create all the abilities and call on setup on each of them
    void Setup()
	{
		foreach (BaseAbilityComponent comp in components)
		{
			comp.OnSetup ();
		}
	}

	public void SetUpAbilities(Dictionary<string, int> abilitiesMapping)
	{
		if (components == null)
            components = new List<BaseAbilityComponent> ();
		
		foreach (string ability in abilitiesMapping.Keys)
		{
			Ability abil = GameManager.instance.AbilitiesDatabase.Find (x => x.Id == ability);

			if (ability != null)
			{
				BaseAbilityComponent comp = abil.CreateComponent (this.gameObject);
				comp.PlayerId = this.PlayerId;
                components.Add(comp);
			}
			else
			{
				Debug.Log ("Error : Couldn't find ability");
			}
		}

		foreach (BaseAbilityComponent component in components)
		{
			component.OnSetup ();
		}

		Setup ();
	}
}

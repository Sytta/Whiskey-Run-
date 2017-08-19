using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityController : MonoBehaviour
{
	[SerializeField] private Button testButton;
	private List<Ability> abilities;

    // Reference to Playerinfo's ability selection
    Dictionary<BaseAbility, Input> abilitySelection;

    // Create all the abilities and call on setup on each of them
    void Setup() { }

	void Start()
	{
		testButton.onClick.AddListener (delegate { AddAbility(testButton.gameObject.name); });
		abilities = new List<Ability> ();
		abilities.Add ((Lasso)ScriptableObject.CreateInstance (typeof(Lasso)));
	}

	void AddAbility(string name)
	{
		Ability ability = abilities.Find (x => x.Name == "Lasso");
		if (ability != null)
		{
			ability.Initialize (this.gameObject);
		}
		else
		{
			Debug.Log ("Error : Couldn't find ability");
		}
	}
}

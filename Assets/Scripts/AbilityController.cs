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

    // Reference to Playerinfo's ability selection
	Dictionary<string, BaseAbilityComponent> abilitySelection;

    // Create all the abilities and call on setup on each of them
    void Setup() { }

	void Start()
	{
		abilitySelection = new Dictionary<string, BaseAbilityComponent> ();
		testButton.onClick.AddListener (delegate { AddAbility(testButton.gameObject.name); });
	}

	void Update()
	{
		float verticalInput = Input.GetAxisRaw ("Vertical");
		if (verticalInput != 0)
		{
			abilitySelection ["Vertical"].Use (new Vector3 (0.0f, 0.0f, 0.0f));
		}
	}

	void AddAbility(string name)
	{
		Ability ability = database.Abilities.Find (x => x.Name == "Lasso");
		if (ability != null)
		{
			abilitySelection.Add("Vertical", ability.CreateComponent (this.gameObject));
		}
		else
		{
			Debug.Log ("Error : Couldn't find ability");
		}
	}
}

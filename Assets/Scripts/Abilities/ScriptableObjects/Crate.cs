using System;
using UnityEngine;

[CreateAssetMenu (menuName = "Abilities/Crate")]
public class Crate : Ability
{
	public override BaseAbilityComponent CreateComponent(GameObject obj)
	{
		CrateComponent crate = obj.GetComponent<CrateComponent> ();

		if (!crate)
		{
			crate = obj.AddComponent<CrateComponent> ();
			Debug.Log ("Created crate");
		}

		crate.Ability = this;

		return crate;
	}
}
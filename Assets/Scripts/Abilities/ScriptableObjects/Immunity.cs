using System;
using UnityEngine;

[CreateAssetMenu (menuName = "Abilities/Immunity")]
public class Immunity : Ability
{
	public override BaseAbilityComponent CreateComponent(GameObject obj)
	{
		ImmunityComponent immunity = obj.GetComponent<ImmunityComponent> ();

		if (!immunity)
		{
			immunity = obj.AddComponent<ImmunityComponent> ();
			Debug.Log ("Created immunity");
		}

		immunity.AbilityId = Id;
		immunity.Name = Name;
		immunity.Cost = Cost;
		immunity.Image = Image;
		immunity.Sound = Sound;
		immunity.CoolDown = CoolDown;

		return immunity;
	}
}

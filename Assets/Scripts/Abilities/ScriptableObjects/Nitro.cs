using System;
using UnityEngine;

[CreateAssetMenu (menuName = "Abilities/Nitro")]
public class Nitro : Ability
{
	public override BaseAbilityComponent CreateComponent(GameObject obj)
	{
		NitroComponent nitro = obj.GetComponent<NitroComponent> ();

		if (!nitro)
		{
			nitro = obj.AddComponent<NitroComponent> ();
			Debug.Log ("Created nitro");
		}

		nitro.AbilityId = Id;
		nitro.Name = Name;
		nitro.Cost = Cost;
		nitro.Image = Image;
		nitro.Sound = Sound;
		nitro.CoolDown = CoolDown;

		return nitro;
	}
}


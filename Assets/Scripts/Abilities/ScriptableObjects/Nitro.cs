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

		nitro.Ability = this;

		return nitro;
	}
}


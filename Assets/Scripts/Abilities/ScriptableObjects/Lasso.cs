using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Abilities/Lasso")]
public class Lasso : Ability
{	
	public override BaseAbilityComponent CreateComponent(GameObject obj)
	{
		LassoComponent lasso = obj.GetComponent<LassoComponent> ();

		if (!lasso)
		{
			lasso = obj.AddComponent<LassoComponent> ();
			Debug.Log ("Created lasso");
		}

		lasso.Name = Name;
		lasso.Cost = Cost;
		lasso.Image = Image;
		lasso.Sound = Sound;
		lasso.CoolDown = CoolDown;

		return lasso;
	}
}


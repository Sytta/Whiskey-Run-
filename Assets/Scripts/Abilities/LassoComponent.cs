using System;
using UnityEngine;

public class LassoComponent : BaseAbilityComponent
{
	public override void OnSetup() { }

	public override void Use(Vector3 direction)
	{
		if (!VerifyCanUse())
		{
			return;
		}

		Debug.Log ("Using lasso!");

		currentCoolDownTimer = Ability.CoolDown;
		StartCoroutine (CoolDownTimer());
	}

	public override bool IsReady() { return false; }
}


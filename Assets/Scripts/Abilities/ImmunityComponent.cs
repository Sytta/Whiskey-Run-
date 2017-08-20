using System;
using UnityEngine;

public class ImmunityComponent : BaseAbilityComponent
{
	public override void OnSetup() { }

	public override void Use(Vector3 direction)
	{
		// Failsafe
		if (currentCoolDownTimer != 0)
		{
			Debug.Log ("Oops! Please wait cooldown to use immunity...");
			return;
		}

		Debug.Log ("Using immunity!");

		currentCoolDownTimer = CoolDown;
		StartCoroutine (CoolDownTimer());
	}

	public override bool IsReady() { return false; }
}


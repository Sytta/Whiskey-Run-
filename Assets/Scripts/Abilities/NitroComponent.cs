using System;
using UnityEngine;

public class NitroComponent : BaseAbilityComponent
{
	public override void OnSetup() { }

	public override void Use(Vector3 direction)
	{
		// Failsafe
		if (currentCoolDownTimer != 0)
		{
			Debug.Log ("Oops! Please wait cooldown to use nitro...");
			return;
		}

		Debug.Log ("Using nitro!");

		currentCoolDownTimer = CoolDown;
		StartCoroutine (CoolDownTimer());
	}

	public override bool IsReady() { return false; }
}


using System;
using UnityEngine;

public class ImmunityComponent : BaseAbilityComponent
{
    bool usingImmunity = false;

	public override void OnSetup() { }

	public override void Use(Vector3 direction)
	{
		if (!VerifyCanUse())
		{
			return;
		}

		Debug.Log ("Using immunity!");

        if (!usingImmunity)
        {
            usingImmunity = true;
            currentCoolDownTimer = Ability.CoolDown;
            StartCoroutine(CoolDownTimer());
        } else
        {
            usingImmunity = false;
        }

		
	}

	public override bool IsReady() { return false; }
}


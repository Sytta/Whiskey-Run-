using System;
using UnityEngine;

public class NitroComponent : BaseAbilityComponent
{
	public override void OnSetup() { }

	public override void Use(Vector3 direction )
	{
        if (GameManager.instance.caravanSpanwer.caravans[PlayerId - 1].GetComponent<NitroComponent>() == null)
        {
            Debug.Log("Dont have nitro");
            return;
        }
		if (!VerifyCanUse())
		{
			return;
		}

		Debug.Log ("Using nitro!");

        // Add speed to the caravan using it
        GameManager.instance.caravanSpanwer.caravans[PlayerId - 1].GetComponent<MotionControl>().AddModifier(5f, 5f, 2f);


        // Start cool down
        currentCoolDownTimer = Ability.CoolDown;
		StartCoroutine (CoolDownTimer());
	}

	public override bool IsReady() { return false; }
}


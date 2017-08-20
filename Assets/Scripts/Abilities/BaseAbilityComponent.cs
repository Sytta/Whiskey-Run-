using System;
using System.Collections;
using UnityEngine;

public class BaseAbilityComponent : MonoBehaviour
{
	[HideInInspector] public Ability Ability { get; set; }
	//[HideInInspector] public int Charges { get; set; }
	public int PlayerId;
	public float currentCoolDownTimer;

	public virtual void OnSetup() { }

	public virtual void Use(Vector3 direction) { }

	public virtual bool IsReady() { return false; }

	public virtual float GetCoolDown() { return currentCoolDownTimer; }

	protected IEnumerator CoolDownTimer()
	{
		while (currentCoolDownTimer != 0.0f)
		{
			yield return new WaitForSecondsRealtime (1.0f);
			currentCoolDownTimer--;
		}
	}

	public virtual bool VerifyCanUse()
	{
		// Failsafe
		if (currentCoolDownTimer != 0)
		{
			Debug.Log ("Oops! Please wait cooldown to use ability...");
			return false;
		}

		if (Ability.Consumable)
		{
			if (GameManager.instance.players[PlayerId - 1].Abilities[Ability.Id] == 0)
			{
				Debug.Log ("Oops! Player" + PlayerId + "have no more charges...");
				return false;
			} else
            {
                // Decrease it
                Debug.Log("Ability charges before: " + GameManager.instance.players[PlayerId - 1].Abilities[Ability.Id]);
                GameManager.instance.players[PlayerId - 1].Abilities[Ability.Id]--;
                Debug.Log("Ability charges after: " + GameManager.instance.players[PlayerId - 1].Abilities[Ability.Id]);
            }
		}

		return true;
	}
}


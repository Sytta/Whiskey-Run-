using System;
using System.Collections;
using UnityEngine;

public class BaseAbilityComponent : MonoBehaviour
{
	[HideInInspector] public Ability Ability { get; set; }
	[HideInInspector] public int Charges { get; set; }
	public int PlayerId;
	/*[HideInInspector] public string AbilityId { get; set; }
	[HideInInspector] public string Name { get; set; }
	[HideInInspector] public float Cost { get; set; }
	[HideInInspector] public Sprite Image { get; set; }
	[HideInInspector] public AudioClip Sound { get; set; }
	[HideInInspector] public float CoolDown { get; set; }
	[HideInInspector] public int[] Input { get; set; }*/
	protected float currentCoolDownTimer;

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
			Debug.Log ("Oops! Please wait cooldown to use immunity...");
			return false;
		}

		if (Ability.Consumable)
		{
			if (Charges == 0)
			{
				Debug.Log ("Oops! You have no more charges...");
				return false;
			}
		}

		return true;
	}
}


using System;
using System.Collections;
using UnityEngine;

public class BaseAbilityComponent : MonoBehaviour
{
	[HideInInspector] public string Name { get; set; }
	[HideInInspector] public float Cost { get; set; }
	[HideInInspector] public Sprite Image { get; set; }
	[HideInInspector] public AudioClip Sound { get; set; }
	[HideInInspector] public float CoolDown { get; set; }
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
}


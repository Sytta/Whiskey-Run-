using System;
using UnityEngine;

public class BaseAbilityComponent : MonoBehaviour
{
	[HideInInspector] public string Name { get; set; }
	[HideInInspector] public float Cost { get; set; }
	[HideInInspector] public Sprite Image { get; set; }
	[HideInInspector] public AudioClip Sound { get; set; }
	[HideInInspector] public float CoolDown { get; set; }

	public virtual void OnSetup() { }

	public virtual void Use(Vector3 direction) { }

	public virtual bool IsReady() { return false; }

	public virtual float GetCoolDown() { return 0.0f; }
}


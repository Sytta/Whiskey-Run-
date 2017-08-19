using System;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
	public virtual string Name { get { return "Ability"; } }
	public virtual float Cost { get { return 10.0f; } }
	public Sprite Image;
	public AudioClip Sound;
	public float CoolDown = 1f;

	public abstract void Initialize(GameObject obj);
	public abstract void TriggerAbility();
}



using System;
using UnityEngine;

[CreateAssetMenu (menuName = "Abilities/Ability")]
public class Ability : ScriptableObject
{
	public string Name;
	public string Description;
	public int Cost;
	public Sprite Image;
	public AudioClip Sound;
	public float CoolDown;

	public virtual BaseAbilityComponent CreateComponent(GameObject obj) { return null; }
}



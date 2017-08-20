using System;
using UnityEngine;

[CreateAssetMenu (menuName = "Abilities/Ability")]
public class Ability : ScriptableObject
{
	public string Id;
	public string Name;
	public string Description;
	public int Cost;
	public Sprite Image;
	public Sprite Controls;
	public AudioClip Sound;
	public float CoolDown;
	public bool Purchasable;
	public bool Locked;
	public string[] Input;
	public bool Consumable;

	public virtual BaseAbilityComponent CreateComponent(GameObject obj) { return null; }
}



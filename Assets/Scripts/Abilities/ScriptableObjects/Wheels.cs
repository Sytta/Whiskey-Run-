﻿using System;
using UnityEngine;

[CreateAssetMenu (menuName = "Abilities/Wheels")]
public class Wheels : Ability
{
	public override BaseAbilityComponent CreateComponent(GameObject obj)
	{
		Debug.Log ("Oops! Our developpers didn't implement this item yet...");
		return null;
	}
}

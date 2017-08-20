using System;
using UnityEngine;

public class CrateComponent : BaseAbilityComponent
{
	public override void OnSetup() { }

	public override void Use(Vector3 direction )
	{
		GameManager.instance.players[PlayerId - 1].Abilities[Ability.Id]--;
	}

	public override bool IsReady() { return false; }
}


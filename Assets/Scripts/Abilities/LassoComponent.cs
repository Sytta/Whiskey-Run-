using System;
using UnityEngine;

public class LassoComponent : BaseAbilityComponent
{
	public override void OnSetup() { }

	public override void Use(Vector3 direction)
	{
		Debug.Log ("Using Lasso!");
	}

	public override bool IsReady() { return false; }

	public override float GetCoolDown() { return 0.0f; }
}


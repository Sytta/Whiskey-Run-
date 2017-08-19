using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (menuName = "Abilities/Lasso")]
public class Lasso : Ability
{
	public override string Name { get { return "Lasso"; } }
	public override float Cost { get { return 25.0f; } }
	
	public override void Initialize(GameObject obj)
	{
		if (!obj.GetComponent<LassoComponent> ())
		{
			obj.AddComponent<LassoComponent> ();
			Debug.Log ("Created lasso");
		}
	}

	public override void TriggerAbility()
	{
		Debug.Log ("Ability Used");
	}
}


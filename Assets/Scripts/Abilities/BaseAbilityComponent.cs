using System;
using UnityEngine;

public class BaseAbilityComponent : MonoBehaviour
{
	void OnSetup() { }

	void Use(Vector3 direction) { }

	bool IsReady() { return false; }

	float GetCoolDown() { return 0.0f; }
}


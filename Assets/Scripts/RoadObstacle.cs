﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadObstacle : MonoBehaviour {
	public bool armed = false;

	[SerializeField]
	Animator obstacleBreakAnimator;

	private void OnTriggerEnter(Collider other)
	{
		if (!armed)
		{
			return;
		}

		var motControl = other.GetComponentInParent<MotionControl>();
		if (motControl && armed)
		{
			motControl.currentSpeed = 0;
			motControl.AddModifier(-0.25f, -0.25f, 2);
			Destroy(GetComponent<InventoryWrecker>());
			if (obstacleBreakAnimator)
			{
				obstacleBreakAnimator.SetTrigger("Break");
			}
			armed = false;
		}
	}
}

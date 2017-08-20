using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadObstacle : MonoBehaviour {

	bool armed = false;


	private void Start()
	{

	}

	private void OnTriggerEnter(Collider other)
	{
		var motControl = other.GetComponentInParent<MotionControl>();
		if (motControl)
		{
			motControl.currentSpeed = 0;
			motControl.AddModifier(-0.25f, -0.25f, 2);
		}
	}
}

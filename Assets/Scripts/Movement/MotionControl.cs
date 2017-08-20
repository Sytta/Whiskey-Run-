﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionControl : MonoBehaviour {
	public float currentSpeed = 0.0f;

	[SerializeField]
	float maxSpeed = 10.0f, acceleration = 1.0f, deceleration = 5.0f, rotateSpeed = 30.0f;

	Vector3 targetMoveDirection;
	

	[SerializeField]
	CharacterController movementController;
	[SerializeField]
	AlignToFloor floorChecker;

	/// <summary>
	/// Takes a normalized direction relative to forward (yaxis +1) as the new direction in which to accelerate.
	/// </summary>
	/// <param name="direction">The normalized direction. If set to zero or null, slows to a stop.</param>
	public void AccelerateToward(Vector3 direction) {
		targetMoveDirection = direction;
	}

	void Update()
	{

		if (floorChecker.IsGrounded()) // Adjust speed and rotation from control while on ground
		{
			if (targetMoveDirection != Vector3.zero)
			{
				var step = targetMoveDirection.magnitude * acceleration * Time.deltaTime;
				step = (targetMoveDirection.z < 0) ? -step : step;
				currentSpeed = Mathf.Clamp( currentSpeed + step, -maxSpeed, maxSpeed);
			}
			else
			{
				float step = deceleration * Time.deltaTime;
				if (currentSpeed > 0)
				{
					currentSpeed = Mathf.Max(currentSpeed - step, 0);
				}
				else
				{
					currentSpeed = Mathf.Min(currentSpeed + step, 0);
				}
				
			}
		}

		// Lerp this later
		var turnCoefficient = Time.deltaTime * currentSpeed * rotateSpeed * targetMoveDirection.x;
		var intendedForward = transform.forward + transform.right * turnCoefficient;
		transform.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(intendedForward, floorChecker.floorUpVector), floorChecker.floorUpVector);
		
		// update every frame for gravity
		movementController.SimpleMove(transform.TransformDirection(Vector3.forward).normalized * currentSpeed);
	}
}

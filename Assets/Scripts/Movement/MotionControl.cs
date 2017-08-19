using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionControl : MonoBehaviour {
	float currentSpeed = 0.0f;

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
				currentSpeed = Mathf.Min(currentSpeed + targetMoveDirection.magnitude * acceleration*Time.deltaTime, maxSpeed);
			}
			else
			{
				currentSpeed = Mathf.Max(currentSpeed - deceleration*Time.deltaTime, 0);
			}

			// ROTATE
			if (targetMoveDirection.x != 0.0f)
			{
				transform.Rotate(new Vector3(0, Time.deltaTime * currentSpeed * rotateSpeed * targetMoveDirection.x));
			}
		}
			
		// update every frame for gravity
		movementController.SimpleMove(transform.TransformDirection(Vector3.forward).normalized * currentSpeed);
		
	}
}

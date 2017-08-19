using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionControl : MonoBehaviour {
	float currentSpeed = 0.0f;

	[SerializeField]
	float maxSpeed = 10.0f, acceleration = 1.0f, deceleration = 5.0f, rotateSpeed = 30.0f, groundedDistance = 1.0f;
	[SerializeField]
	float upFixRotationSpeed = 0.6f;

	float raycastDelay = 0.2f;
	float timeSinceLastRaycast = 0.0f;

	Vector3 targetMoveDirection;
	Vector3 floorUpVector;

	bool grounded = false;

	[SerializeField]
	CharacterController movementController;

	/// <summary>
	/// Takes a normalized direction relative to forward (yaxis +1) as the new direction in which to accelerate.
	/// </summary>
	/// <param name="direction">The normalized direction. If set to zero or null, slows to a stop.</param>
	public void AccelerateToward(Vector3 direction) {
		targetMoveDirection = direction;
	}

	public void SetNewTargetUpVector(Vector3 up)
	{
		floorUpVector = up;
	}

	public void SetGrounded(bool grounded)
	{
		this.grounded = grounded;
	}

	void Update()
	{

		// raycast to check distance to ground for grounded and check normal up
		if((timeSinceLastRaycast += Time.deltaTime) > raycastDelay)
		{
			RaycastHit hit = new RaycastHit();
			Physics.Raycast(transform.position, -transform.up, out hit, 4.0f);
			Debug.DrawRay(transform.position, -transform.up);
			floorUpVector = hit.normal;
			grounded = hit.distance <= groundedDistance;
			timeSinceLastRaycast = 0;
		}

		if (grounded) // Adjust speed and rotation from control while on ground
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
		
		// fix chariot up rotation
		if(floorUpVector != transform.up)
		{
			transform.up = Vector3.RotateTowards(transform.up, floorUpVector, upFixRotationSpeed * Time.deltaTime, 200);
		}
		
	}
}

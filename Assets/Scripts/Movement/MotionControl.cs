using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionControl : MonoBehaviour {

	private class Modifier
	{
		public float accelerationMod = 0.0f, maxSpeedMod = 0.0f, timeLeft = 0.0f;

		public Modifier(float accMod, float msMod, float dur)
		{
			accelerationMod = accMod;
			maxSpeedMod = msMod;
			timeLeft = dur;
		}

		public void ApplyTo(MotionControl target)
		{
			target.maxSpeedFactor += maxSpeedMod;
			target.accelerationFactor += accelerationMod;
		}

		public void RemoveFrom(MotionControl target)
		{
			target.maxSpeedFactor -= maxSpeedMod;
			target.accelerationFactor -= accelerationMod;
		}
	}

	List<Modifier> currentModifiers = new List<Modifier>();

	public float currentSpeed = 0.0f;

	[SerializeField]
	float maxSpeed = 10.0f, acceleration = 1.0f, deceleration = 5.0f, rotateSpeed = 30.0f;

	float maxSpeedFactor = 1.0f, accelerationFactor = 1.0f;

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

	/// <summary>
	/// Applies a modifier to caravan motion values as relative factor (e.g. 0.5 = +50%)
	/// </summary>
	/// <param name="accelerationFactorMod">The relative variation to apply to the caravan's acceleration factor</param>
	/// <param name="maxSpeedFactorMod">The relative variation to apply to the caravan's maxSpeed factor</param>
	/// <param name="duration">How long this effect should  last</param>
	public void AddModifier(float accelerationFactorMod, float maxSpeedFactorMod, float duration)
	{
        Debug.Log("Accelerating!");
		var newMod = new Modifier(accelerationFactorMod, maxSpeedFactorMod, duration);
		currentModifiers.Add(newMod);
		newMod.ApplyTo(this);
	}

	void CheckModifierExpiry()
	{
		for (int i = currentModifiers.Count - 1; i >= 0; i--)
		{
			if((currentModifiers[i].timeLeft -= Time.deltaTime) < 0)
			{
				currentModifiers[i].RemoveFrom(this);
				currentModifiers.RemoveAt(i);
			}
		}
		
	}

	void Update()
	{

		CheckModifierExpiry();

		if (floorChecker.IsGrounded()) // Adjust speed and rotation from control while on ground
		{
			if (targetMoveDirection != Vector3.zero && Mathf.Abs(currentSpeed) < maxSpeedFactor*maxSpeed)
			{
				var step = targetMoveDirection.magnitude * acceleration * accelerationFactor * Time.deltaTime;
				step = (targetMoveDirection.z < 0) ? -step : step;
				currentSpeed = Mathf.Clamp( currentSpeed + step, -(maxSpeed*maxSpeedFactor), (maxSpeed*maxSpeedFactor));
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

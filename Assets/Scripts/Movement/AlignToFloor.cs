using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignToFloor : MonoBehaviour {
	[SerializeField]
	float upFixDistanceThreshold = 4.0f, upFixRotationSpeed = 0.6f, groundedDistance = 1.0f, raycastDelay = 0.2f;

	float timeSinceLastRaycast = 0.0f;
	Vector3 floorUpVector;
	bool grounded = false;

	public bool IsGrounded() { return grounded; }

	private void Update()
	{
		// raycast to check distance to ground for grounded and check normal up
		if ((timeSinceLastRaycast += Time.deltaTime) > raycastDelay)
		{
			RaycastHit hit = new RaycastHit();
			if(Physics.Raycast(transform.position, -transform.up, out hit, upFixDistanceThreshold) && hit.collider.CompareTag("ground"))
			{
				floorUpVector = hit.normal;
				grounded = hit.distance <= groundedDistance;
			}
			timeSinceLastRaycast = 0;
		}

		// fix object up rotation
		if ((floorUpVector != null) && (floorUpVector != transform.up))
		{
			transform.up = Vector3.RotateTowards(transform.up, floorUpVector, upFixRotationSpeed * Time.deltaTime, 200);
		}
	}
	
}

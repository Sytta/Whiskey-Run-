using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDetector : MonoBehaviour {
	[SerializeField]
	MotionControl ReadjustmentController;

	// Use this for initialization
	private void OnTriggerEnter(Collider collider)
	{
		if (collider.CompareTag("ground"))
		{
			ReadjustmentController.SetGrounded(true);
		}
	}

	private void OnTriggerExit(Collider collider)
	{
		if (collider.CompareTag("ground"))
		{
			ReadjustmentController.SetGrounded(false);
		}
	}
}

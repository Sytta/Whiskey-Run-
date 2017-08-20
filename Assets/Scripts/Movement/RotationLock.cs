using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLock : MonoBehaviour {
	[SerializeField]
	bool xLock, yLock, zLock;
	Vector3 initialRotation;
	// Use this for initialization
	void Start () {
		initialRotation = transform.rotation.eulerAngles;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		var newRotation = transform.rotation.eulerAngles;
		float x = (xLock) ? initialRotation.x:newRotation.x;
		float y = (yLock) ? initialRotation.y:newRotation.y;
		float z = (zLock) ? initialRotation.z:newRotation.z;
		transform.rotation = Quaternion.Euler(x, y, z);
	}
}

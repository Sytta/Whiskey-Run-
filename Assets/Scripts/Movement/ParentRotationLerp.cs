using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentRotationLerp: MonoBehaviour {

	[SerializeField]
	float LerpRotationSpeed;

	Quaternion previousRotation, targetRotation;

	// Use this for initialization
	void Start () {
		previousRotation = transform.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
		previousRotation = transform.rotation = Quaternion.Slerp(previousRotation, transform.parent.localRotation, LerpRotationSpeed * Time.deltaTime);
	}
}

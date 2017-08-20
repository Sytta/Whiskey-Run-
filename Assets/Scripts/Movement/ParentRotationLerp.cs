using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentRotationLerp: MonoBehaviour {

	[SerializeField]
	float LerpRotationSpeed;

	Quaternion previousRotation, targetRotation;

	Vector3 previousRotationEuler, targetRotationEuler;

	// Use this for initialization
	void Start () {
		previousRotation = transform.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
		var newRotation = Quaternion.Slerp(previousRotation, transform.parent.localRotation, LerpRotationSpeed * Time.deltaTime);
		newRotation = Quaternion.Euler(new Vector3(0f, newRotation.eulerAngles.y, 0f));
		previousRotation = transform.rotation = newRotation;
		//previousRotation = transform.rotation = Quaternion.Slerp(previousRotation, transform.parent.localRotation, LerpRotationSpeed * Time.deltaTime);
	}
}

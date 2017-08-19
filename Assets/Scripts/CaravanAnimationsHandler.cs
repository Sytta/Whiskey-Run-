using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaravanAnimationsHandler : MonoBehaviour {

	[SerializeField]
	Animator CartAnimator, HorseAnimator;
	[SerializeField]
	MotionControl caravanMotionControl;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(CartAnimator != null)
			CartAnimator.SetFloat("currentSpeed", caravanMotionControl.currentSpeed);
		if (HorseAnimator != null)
			HorseAnimator.SetFloat("currentSpeed", caravanMotionControl.currentSpeed);
	}
}

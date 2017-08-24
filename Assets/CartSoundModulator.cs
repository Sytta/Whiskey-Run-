using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartSoundModulator : MonoBehaviour {
	[SerializeField]
	AudioSource soundPlayer;
	[SerializeField]
	MotionControl speedIndicator;
	[SerializeField]
	float volumeFactor = 0.3f;

	// Use this for initialization
	void Start () {
		soundPlayer.Play();
	}
	
	// Update is called once per frame
	void Update () {
		soundPlayer.volume = Mathf.Abs(speedIndicator.currentSpeed*volumeFactor);
	}
}

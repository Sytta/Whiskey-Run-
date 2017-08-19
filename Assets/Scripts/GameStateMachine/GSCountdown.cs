using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameStateMachine : MonoBehaviour
{
	private class GSCountdown : GameState
	{
		private float timeLeft = 0.0f;

		public GSCountdown(GameStateMachine owner) : base(owner) { }

		public override void OnEnter()
		{
			timeLeft = 4.0f;
			// Start countdown

		}

		public override void OnExit()
		{
			// nothin for now
		}

		public override void OnUpdate(float deltaTime)
		{
			// update seconds left and UI?
			if ((timeLeft -= deltaTime) <= 0)
			{
				OnCountdownExpired();
			}
		}

		public void OnCountdownExpired()
		{
			owner.GoToState("InRace");
		}
	}
}

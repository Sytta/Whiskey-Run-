using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class GameStateMachine : MonoBehaviour
{
	private class GSCountdown : GameState
	{
		private float timeLeft = 0.0f;

        private RacingUI racingUI;

		public GSCountdown(GameStateMachine owner) : base(owner) { }

		public override void OnEnter()
		{
			timeLeft = 4.0f;
            owner.currentState = this;
            // Start countdown
            racingUI = GameManager.instance.racingUI.GetComponent<RacingUI>();
            racingUI.InitCountDown(timeLeft.ToString());

        }

		public override void OnExit()
		{
			// nothin for now
		}

		public override void OnUpdate(float deltaTime)
		{
			// update seconds left and UI?
			if ((timeLeft -= deltaTime) <= 1)
			{
				OnCountdownExpired();
			}

            racingUI.SetCountDown(((int)timeLeft).ToString());

        }

		public void OnCountdownExpired()
		{
            racingUI.DisableCountDown();
            owner.GoToState("InRace");
		}
	}
}

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

        bool isReady = false;
		bool playedCountdownSound = false;

		public GSCountdown(GameStateMachine owner) : base(owner) { }

		public override void OnEnter()
		{
			timeLeft = 4.0f;
			playedCountdownSound = false;
			owner.currentState = this; // <- wow... just wow
            
			GameManager.instance.AudioService.PlayMusic("Race");

            // Start countdown
            racingUI = GameManager.instance.racingUI.GetComponent<RacingUI>();

        }

		public override void OnExit()
		{
			// nothin for now
		}

		public override void OnUpdate(float deltaTime)
		{
            // update seconds left and UI?
            if (owner.currentState == this && timeLeft < 4f)
            {
                isReady = true;
            } else
            {
                timeLeft -= deltaTime;
            }
            if (isReady)
            {
                racingUI.InitCountDown(timeLeft.ToString());
                if (racingUI != null)
                {
					if(!playedCountdownSound && (timeLeft -= deltaTime) <= 2)
					{
						GameManager.instance.AudioService.PlayOneShotSFX("ReadyUpGo");
						playedCountdownSound = true;
					}
                    if ((timeLeft -= deltaTime) <= 1)
                    {
                        OnCountdownExpired();
                    }

                    racingUI.SetCountDown(((int)timeLeft).ToString());
                }
            }

        }

		public void OnCountdownExpired()
		{
            racingUI.DisableCountDown();
            owner.GoToState("InRace");
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class GameStateMachine : MonoBehaviour
{
	private class GSSetupRace : GameState
	{

		public GSSetupRace(GameStateMachine owner) : base(owner) { }

		public override void OnEnter()
		{
            Debug.Log("Setting up scene");
            // Ready level
            owner.currentState = this;

            // Show Racing UI
            GameManager.instance.racingUI = Instantiate(GameManager.instance.racingUIPrefab);

            GameManager.instance.racingUI.GetComponent<RacingUI>().DisableCountDown();

            // Spawn caravans
            GameManager.instance.caravanSpanwer.Initialize();

            OnSetupFinished();

        }

		public override void OnExit()
		{
            // ?
        }

		public override void OnUpdate(float deltaTime)
		{
			// nothing for now.
		}

		public void OnSetupFinished()
		{
			owner.GoToState("Countdown");
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameStateMachine : MonoBehaviour
{
	private class GSSetupRace : GameState
	{

		public GSSetupRace(GameStateMachine owner) : base(owner) { }

		public override void OnEnter()
		{
            Debug.Log("Setting up scene");
            // Ready level

            // Show Racing UI
            Instantiate(GameManager.instance.racingUI);

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

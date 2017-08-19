using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameStateMachine : MonoBehaviour
{
	private class GSRoundsOver : GameState
	{
		int winnerId;
		int numberOfPlayersFinished;

		public GSRoundsOver(GameStateMachine owner) : base(owner) { }

		public override void OnEnter()
		{
            owner.currentState = this;
            // Show rounds summary
        }

		public override void OnExit()
		{
			// Hide rounds summary
			// Reset race persistent data for next set of rounds
		}

		public override void OnUpdate(float deltaTime)
		{
			// nothing for now.
		}

		public void OnRematch()
		{
			owner.GoToState("SetupRace");
		}

		public void OnGoToMainMenu()
		{
			owner.GoToState("MainMenu");
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameStateMachine : MonoBehaviour
{
	private class GSShowRaceResults : GameState
	{
		public GSShowRaceResults(GameStateMachine owner) : base(owner) { }

		public override void OnEnter()
		{
            owner.currentState = this;
            // show results

            OnBothPlayersReady();
        }

		public override void OnExit()
		{
			// Hide results
		}

		public override void OnUpdate(float deltaTime)
		{
			// nothing for now.
		}

		public void OnBothPlayersReady()
		{
			// Check if there are rounds left
			// if so
			if (true /* replace with rounds left condition*/)
			{
				owner.GoToState("UpgradesMenu");
			}
			else
			{
				owner.GoToState("RoundsOver");
			}
		}
	}
}

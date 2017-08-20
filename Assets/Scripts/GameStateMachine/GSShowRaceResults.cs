using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameStateMachine : MonoBehaviour
{
	private class GSShowRaceResults : GameState
	{
		public GSShowRaceResults(GameStateMachine owner) : base(owner) { }

        private GameObject ScoreBoard;

        public override void OnEnter()
		{
            owner.currentState = this;
            // show results
            // ScoreBoard = Instantiate(GameManager.instance.PrefabManager.ScoreBoard);
        }

		public override void OnExit()
		{
            // Hide results
            Destroy(ScoreBoard);
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

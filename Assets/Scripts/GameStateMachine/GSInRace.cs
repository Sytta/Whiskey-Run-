using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameStateMachine : MonoBehaviour
{
	private class GSInRace : GameState
	{
		int winnerId;
		int numberOfPlayersFinished;

		public GSInRace(GameStateMachine owner) : base(owner) { }

		public override void OnEnter()
		{
            owner.currentState = this;
			numberOfPlayersFinished = 0;
            // Enable playerInput
            GameManager.instance.caravanSpanwer.EnableCaravanInput();
		}

		public override void OnExit()
		{
			// Destroy caravans through the spawner perhaps
		}

		public override void OnUpdate(float deltaTime)
		{
            // Update nbCrate
            //GameManager.instance.UpdatePlayerInfo();
        }

		public void OnPlayerFinished(int player)
		{
			numberOfPlayersFinished++;
			// Once both players finish, change state
			if (numberOfPlayersFinished == 2)
			{
                // Destroy caravans through the spawner
                GameManager.instance.caravanSpanwer.DestroyCaravans();
				GameManager.instance.caravanSpanwer = null;
                owner.GoToState("ShowRaceResults");
			}
		}
	}
}

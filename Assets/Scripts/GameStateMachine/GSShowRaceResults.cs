using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class GameStateMachine : MonoBehaviour
{
	private class GSShowRaceResults : GameState
	{
        private PlayerInfo[] playerInfos;
        private GameObject scoreBoard;

        private Button[] buttons;

        public GSShowRaceResults(GameStateMachine owner) : base(owner) { }

        public override void OnEnter()
		{
            owner.currentState = this;

            // Disable ability controller
            for (int i = 0; i < GameManager.instance.caravanSpanwer.caravans.Count; i++)
            {
                GameManager.instance.caravanSpanwer.caravans[i].GetComponent<AbilityController>().enabled = false;
            }

            playerInfos = GameManager.instance.players;

            // show results
            scoreBoard = Instantiate(GameManager.instance.PrefabManager.ScoreBoard);

            scoreBoard.GetComponent<ScoreBoard>().Initialize();
			for (int i = 0; i < GameManager.instance.nbPlayers; i++)
			{
				GameManager.instance.players [i].ResetCrates ();
			}
        }

		public override void OnExit()
		{
            // Hide results
            Destroy(scoreBoard);
		}

		public override void OnUpdate(float deltaTime)
		{
			if (Input.GetAxis ("AAbility_P1") > 0.0f || Input.GetAxis ("AAbility_P2") > 0.0f)
			{
				GameObject selectedButton = scoreBoard.GetComponent<ScoreBoard> ().buttons [
					                            scoreBoard.GetComponent<ScoreBoard> ().selectedButton];
				if (selectedButton.name == "ContinueButton")
					NextRound ();
				else
					Quit ();
			}
		}

        public void Quit()
        {
            owner.GoToState("RoundsOver");
        }

        public void NextRound()
        {
            owner.GoToState("UpgradesMenu");
        }
	}
}

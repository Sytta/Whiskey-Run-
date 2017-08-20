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

            playerInfos = GameManager.instance.players;

            // show results
            scoreBoard = Instantiate(GameManager.instance.PrefabManager.ScoreBoard);

            scoreBoard.GetComponent<ScoreBoard>().Initialize();

            // Add listener
            buttons = scoreBoard.GetComponentsInChildren<Button>();

            for (int i = 0; i < buttons.Length; i ++)
            {
                if (buttons[i].name == "ContinueButton")
                    buttons[i].onClick.AddListener(NextRound);
                else
                    buttons[i].onClick.AddListener(Quit);
            }

        }

		public override void OnExit()
		{
            // Hide results
            Destroy(scoreBoard);
		}

		public override void OnUpdate(float deltaTime)
		{
			// nothing for now.
		}

		/*public void OnBothPlayersReady()
		{
			// Check if there are rounds left
			// if so
			if (true /* replace with rounds left condition*//*)
			/*{
				owner.GoToState("UpgradesMenu");
			}
			else
			{
				owner.GoToState("RoundsOver");
			}
		}*/

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

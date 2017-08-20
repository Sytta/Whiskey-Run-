using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameStateMachine : MonoBehaviour
{
	private class GSInRace : GameState
	{
		int winnerId;
        bool[] playerFinished;

		public GSInRace(GameStateMachine owner) : base(owner) { }

		public override void OnEnter()
		{
            owner.currentState = this;
			playerFinished = new bool[2] { false, false };
            // Enable playerInput
            GameManager.instance.caravanSpanwer.EnableCaravanInput();
		}

		public override void OnExit()
		{
            // Destroy caravans through the spawner perhaps
            //GameManager.instance.caravanSpanwer.DestroyCaravans();
            //GameManager.instance.caravanSpanwer = null;

            // Destory RacingUI
            Destroy(GameManager.instance.racingUI);
        }

		public override void OnUpdate(float deltaTime)
		{
            // Add code for all player actions
            // GameManager.instance.UpdatePlayerInfo();
            // Check if player reached position
            for (int i = 0; i < GameManager.instance.caravanSpanwer.caravans.Count; i++)
            {
                GameObject caravan = GameManager.instance.caravanSpanwer.caravans[i];
                int playerId = caravan.GetComponent<CaravanInput>().playerId - 1;
                if (caravan.transform.position.x >= GameObject.FindGameObjectWithTag("goal").transform.position.x && !playerFinished[playerId])
                {
                    OnPlayerFinished(playerId);
                    Debug.Log("Player " + caravan.GetComponent<CaravanInput>().playerId + " finished!");
                }
                
            }
            
            
        }

		public void OnPlayerFinished(int player)
		{
			if (!playerFinished[player])
            {
                // Disable player caravan input and slowly come to a stop
                GameManager.instance.caravanSpanwer.DisableCaravanInput(player); 

                // If the other player hasn't finished
                if (!playerFinished[(player + 1) % 2])
                {
                    // Set Winner / Looser
                    GameManager.instance.players[player].isWinner = true;
                    GameManager.instance.players[(player + 1) % 2].isWinner = false;
                    Debug.Log("The winner is player " + (player + 1));
                    Debug.Log("The looser is player " + ((player + 1) % 2 + 1));

                    // Show win text
                    GameManager.instance.racingUI.GetComponent<RacingUI>().SetWinner(player, "First place!");
                } 

                playerFinished[player] = true;
            }
			// Once both players finish, change state
			//if (playerFinished[0] && playerFinished[1])
            if (playerFinished[0])
            {
                owner.GoToState("ShowRaceResults");
            }
		}
	}
}

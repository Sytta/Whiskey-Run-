﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class GameStateMachine : MonoBehaviour
{
    private class GSUpgradeMenu : GameState
    {
        public GSUpgradeMenu(GameStateMachine owner) : base(owner) { }

		private GameObject Shop;
		private Button[] start;

		bool readyPlayer1 = false;
		bool readyPlayer2 = false;

        public override void OnEnter()
        {
            // Show the tutorial
            owner.currentState = this;
			Shop = Instantiate (GameManager.instance.PrefabManager.Shop);
			GameManager.instance.AudioService.PlayMusic("Menu");
        }

        public override void OnExit()
        {
            // Hide the tutorial
			Destroy(Shop);
			readyPlayer1 = false;
			readyPlayer2 = false;

            // Enable ability controller
            for (int i = 0; i < GameManager.instance.caravanSpanwer.caravans.Count; i++)
            {
                GameManager.instance.caravanSpanwer.caravans[i].GetComponent<AbilityController>().enabled = true;
            }
        }

        public override void OnUpdate(float deltaTime)
        {
            // Verify if players are ready.
			if (Input.GetKeyDown (KeyCode.Joystick1Button7))
			{
				if (!readyPlayer1)
				{
					readyPlayer1 = true;
					Shop.GetComponent<ShopController> ().SetReady (0);
				}
			}
			if (Input.GetKeyDown (KeyCode.Joystick2Button7))
			{
				if (!readyPlayer2)
				{
					readyPlayer2 = true;
					Shop.GetComponent<ShopController> ().SetReady (1);
				}
			}
			if (readyPlayer1 && readyPlayer2)
			{
				OnClickedPlay ();
			}
        }

        public void OnClickedPlay()
        {
			Debug.Log ("Going to SetupRace");
			owner.GoToState("SetupRace");
		}
    }
}

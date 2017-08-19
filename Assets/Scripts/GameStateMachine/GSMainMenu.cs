using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameStateMachine : MonoBehaviour
{
	private class GSMainMenu : GameState
	{
		public GSMainMenu(GameStateMachine owner) : base(owner) { }

		public override void OnEnter()
		{
            // Show Main Menu ui
            Debug.Log("Going from MainMenu to Tutorial");
            OnClickedPlay();

        }

		public override void OnExit()
		{
			// Hide the main menu ui
		}

		public override void OnUpdate(float deltaTime)
		{
			// nothing for now.
		}

		public void OnClickedPlay()
		{
			owner.GoToState("Tutorial");
		}
	}
}

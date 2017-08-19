using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameStateMachine : MonoBehaviour
{
	private class GSTutorial : GameState
	{
		public GSTutorial(GameStateMachine owner) : base(owner) { }

		public override void OnEnter()
		{
			// Show the tutorial
		}

		public override void OnExit()
		{
			// Hide the tutorial
		}

		public override void OnUpdate(float deltaTime)
		{
			// nothing for now.
		}

		public void OnClickedPlay()
		{
			owner.GoToState("RaceSetup");
		}
	}
}

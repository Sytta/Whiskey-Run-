using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameStateMachine : MonoBehaviour
{
	private class GSTutorial : GameState
	{
		public GSTutorial(GameStateMachine owner) : base(owner) { }

		private enum State
		{
			CONTROLS,
			TUTORIAL,
			END
		}
		private State currentState = State.CONTROLS;
		private bool canControl = true;

		public override void OnEnter()
		{
            Debug.Log("Going from Tutorial to RaceSetup");
            owner.currentState = this;
            // Show the tutorial
            OnClickedPlay();
        }

		public override void OnExit()
		{
			// Hide the tutorial
		}

		private void RunState()
		{
			switch (currentState)
			{
			case State.CONTROLS:
				break;
			case State.TUTORIAL:
				break;
			case State.END:
				OnClickedPlay ();
				break;
			}
		}

		private void IncrementState()
		{
			currentState++;
			RunState ();
		}

		public override void OnUpdate(float deltaTime)
		{
			// nothing for now.
			if (Input.GetAxis ("AAbility_P1") > 0.0f || Input.GetAxis ("AAbility_P2") > 0.0f || Input.GetKeyDown (KeyCode.Return))
			{
				if (canControl)
				{
					canControl = false;
					IncrementState ();
				}
			}
			else
			{
				canControl = true;
			}
		}

		public void OnClickedPlay()
		{
			owner.GoToState("SetupRace");
		}
	}
}

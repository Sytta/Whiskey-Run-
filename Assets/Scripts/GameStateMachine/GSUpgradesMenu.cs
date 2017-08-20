using System;
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

        public override void OnEnter()
        {
            // Show the tutorial
            owner.currentState = this;
			Shop = Instantiate (GameManager.instance.PrefabManager.Shop);
        }

        public override void OnExit()
        {
            // Hide the tutorial
			Destroy(Shop);
        }

        public override void OnUpdate(float deltaTime)
        {
            // nothing for now.
			if (Input.GetKeyDown (KeyCode.Joystick1Button7) || Input.GetKeyDown(KeyCode.Space))
			{
				OnClickedPlay ();

			}
        }

        public void OnClickedPlay()
        {
			Debug.Log ("Going to RoundsOver");
			owner.GoToState("RoundsOver");
		}
    }
}

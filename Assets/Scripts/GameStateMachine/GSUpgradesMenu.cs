using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameStateMachine : MonoBehaviour
{
    private class GSUpgradeMenu : GameState
    {
        public GSUpgradeMenu(GameStateMachine owner) : base(owner) { }

        public override void OnEnter()
        {
            // Show the tutorial
            OnClickedPlay();
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
            owner.GoToState("RoundsOver");
        }
    }
}

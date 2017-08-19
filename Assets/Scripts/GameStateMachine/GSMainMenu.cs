using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public partial class GameStateMachine : MonoBehaviour
{
	private class GSMainMenu : GameState
	{
        Button startGame;

		public GSMainMenu(GameStateMachine owner) : base(owner) { }

		public override void OnEnter()
		{
            // Show Main Menu ui
            /*Debug.Log("Going from MainMenu to Tutorial");
            OnClickedPlay();*/
            owner.currentState = this;
            GameObject mainMenu = Instantiate (GameManager.instance.mainMenuPrefab);
            startGame = mainMenu.GetComponentInChildren<Button>();
            startGame.onClick.AddListener(OnClickedPlay);
            Debug.Log("In main menu");
            
        }

		public override void OnExit()
		{
            // Hide the main menu ui
            startGame.onClick.RemoveAllListeners();
           
		}

		public override void OnUpdate(float deltaTime)
		{
			// nothing for now.
		}

		public void OnClickedPlay()
		{
            Debug.Log("Going to Tutorial");

            SceneManager.LoadScene("Scene_Race01");
            
            owner.GoToState("Tutorial");

           

		}
	}
}

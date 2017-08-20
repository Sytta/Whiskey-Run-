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
        GameObject mainMenu;

        public GSMainMenu(GameStateMachine owner) : base(owner) { }

		public override void OnEnter()
		{
            // Show Main Menu ui
            owner.currentState = this;
            if (SceneManager.GetActiveScene().name != "Boot")
            {
                SceneManager.LoadScene("Boot");

                SceneManager.sceneLoaded += OnSceneLoaded;
            }
            mainMenu = Instantiate(GameManager.instance.PrefabManager.MainMenuPrefab);
			GameManager.instance.AudioService.PlayMusic("Menu");
			Debug.Log("In main menu");
        }

		public override void OnExit()
		{
            // Hide the main menu ui
            Debug.Log("Destroy main menu");
            Destroy(mainMenu);
		}

		public override void OnUpdate(float deltaTime)
		{
            // nothing for now.
			if (Input.GetAxis ("AAbility_P1") > 0.0f || Input.GetAxis ("AAbility_P2") > 0.0f || Input.GetKeyDown(KeyCode.Return))
			{
				GameObject selectedButton = mainMenu.GetComponent<MainMenu> ().buttons [
					mainMenu.GetComponent<MainMenu> ().selectedButton];
				if (selectedButton.name == "StartButton")
					OnClickedPlay ();
				else
					Application.Quit ();
			}
		}

		public void OnClickedPlay()
		{
            Debug.Log("Going to Tutorial");
            owner.GoToState("Tutorial");

        }

        // called second
        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            Debug.Log("OnSceneLoaded: " + scene.name);
                
        }

        

		
	}
}

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
        GameObject mainMenu;


        public GSMainMenu(GameStateMachine owner) : base(owner) { }

		public override void OnEnter()
		{
            // Show Main Menu ui
            /*Debug.Log("Going from MainMenu to Tutorial");
            OnClickedPlay();*/
            owner.currentState = this;
            if (SceneManager.GetActiveScene().name != "Boot")
            {
                SceneManager.LoadScene("Boot");

                SceneManager.sceneLoaded += OnSceneLoaded;
            }
            mainMenu = Instantiate(GameManager.instance.PrefabManager.MainMenuPrefab);
            startGame = mainMenu.GetComponentInChildren<Button>();
            startGame.onClick.AddListener(OnClickedPlay);
            Debug.Log("In main menu");
        }

		public override void OnExit()
		{
            // Hide the main menu ui
            Debug.Log("Destroy main menu");
            startGame.onClick.RemoveAllListeners();
            Destroy(mainMenu);
            Destroy(startGame);
           
		}

		public override void OnUpdate(float deltaTime)
		{
            // nothing for now.
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public partial class GameStateMachine : MonoBehaviour
{
	private class GSSetupRace : GameState
	{

		public GSSetupRace(GameStateMachine owner) : base(owner) { }

		public override void OnEnter()
		{
            Debug.Log("Setting up scene");
            // Ready level
            owner.currentState = this;

            if (SceneManager.GetActiveScene().name != "Scene_Race01")
            {
                SceneManager.LoadScene("Scene_Race01");

                SceneManager.sceneLoaded += OnSceneLoaded;
            } else
            {
                Initialize();
            }

        }

        void Initialize()
        {
            // Find caravan spawner and Spawn caravans
            GameManager.instance.caravanSpanwer = GameObject.FindObjectOfType<CaravanSpawner>();
            if (GameManager.instance.caravanSpanwer != null)
                GameManager.instance.caravanSpanwer.Initialize();

            //  Remove all dropped items
            GameObject[] droppedItems = GameObject.FindGameObjectsWithTag("dropped");
            for (int i = 0; i < droppedItems.Length; i++)
            {
                Destroy(droppedItems[i]);
            }

            // Show Racing UI
            if (GameManager.instance.racingUI != null)
            {
                Destroy(GameManager.instance.racingUI);
            }

            GameManager.instance.racingUI = Instantiate(GameManager.instance.PrefabManager.RacingUI);

            GameManager.instance.racingUI.GetComponent<RacingUI>().DisableCountDown();

            OnSetupFinished();
        }

        // called second
        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            
            Initialize();

            Debug.Log("OnSceneLoaded: " + scene.name);
        }

        public override void OnExit()
		{
            // ?
        }

		public override void OnUpdate(float deltaTime)
		{
			// nothing for now.
		}

		public void OnSetupFinished()
		{
			owner.GoToState("Countdown");
		}
	}
}

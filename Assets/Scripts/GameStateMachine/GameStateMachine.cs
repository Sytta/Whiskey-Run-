using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameStateMachine : MonoBehaviour
{

	private abstract class GameState
	{
		protected GameStateMachine owner;

		public GameState(GameStateMachine owner)
		{
			this.owner = owner;
		}

		public abstract void OnEnter();

		public abstract void OnExit();

		public abstract void OnUpdate(float deltaTime);
	}

	Dictionary<string, GameState> gameStates;

	private GameState currentState;

	private void LoadUpStates()
	{
        // Add entries to the state dictionary here.
        gameStates = new Dictionary<string, GameState>();

		gameStates.Add("MainMenu", new GSMainMenu(this));
		gameStates.Add("Tutorial", new GSTutorial(this));
		gameStates.Add("SetupRace", new GSSetupRace(this)); 
		gameStates.Add("Countdown", new GSCountdown(this)); 
		gameStates.Add("InRace", new GSInRace(this)); 
		gameStates.Add("ShowRaceResults", new GSShowRaceResults(this)); 
		gameStates.Add("UpgradesMenu", new GSUpgradeMenu(this)); 
		gameStates.Add("RoundsOver", new GSRoundsOver(this)); 


	}

	public void GoToState(string stateName)
	{
		GameState nextState = null;
		if (gameStates.TryGetValue(stateName, out nextState)){
            if (currentState != null)
			    currentState.OnExit();
			nextState.OnEnter();
		}
		else
		{
			Debug.LogError("No state with this name was found: " + stateName );
		}
	}

	// Use this for initialization
	void Start()
	{
		LoadUpStates();
        GoToState("MainMenu");
	}

	// Update is called once per frame
	void Update()
	{
		foreach(var statesEntry in gameStates)
		{
			statesEntry.Value.OnUpdate(Time.deltaTime);
		}
	}
}

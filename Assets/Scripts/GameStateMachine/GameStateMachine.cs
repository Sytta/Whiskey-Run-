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
		gameStates["MainMenu"] = new GSMainMenu(this);
		gameStates["Tutorial"] = new GSTutorial(this);
		gameStates["SetupRace"] = new GSTutorial(this); //Change class
		gameStates["Countdown"] = new GSTutorial(this); //Change class
		gameStates["InRace"] = new GSTutorial(this); //Change class
		gameStates["ShowRaceResults"] = new GSTutorial(this); //Change class
		gameStates["UpgradesMenu"] = new GSTutorial(this); //Change class
		gameStates["RoundsOver"] = new GSTutorial(this); //Change class

	}

	public void GoToState(string stateName)
	{
		GameState nextState = null;
		if (gameStates.TryGetValue(stateName, out nextState)){
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

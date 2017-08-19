using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public int nbPlayers = 2;
	[HideInInspector] public PlayerInfo[] players;

	[SerializeField] public List<Ability> AbilitiesDatabase;

    [SerializeField] public CaravanSpawner caravanSpanwer;

    public static GameManager instance = null;

    //Awake is always called before any Start functions
	void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Call the InitGame function to initialize the first level 
        InitGame();
    }

    void InitGame()
	{
		players = new PlayerInfo[nbPlayers];

		for (int i = 0; i < nbPlayers; i++)
		{
			players [i] = new PlayerInfo ();
		}
	}
}

